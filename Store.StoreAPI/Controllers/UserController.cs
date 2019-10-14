using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Store.BL.Models;
using Store.BL.Services;

namespace Store.StoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IHttpContextAccessor _context;

        public UserController(IUserService userService, IHttpContextAccessor context)
        {
            _userService = userService;
            _context = context;
        }

        [HttpGet("userList")]
        [Authorize]
        public async Task<ActionResult<UserView>> GetAllUsers()
        {
            var users = await _userService.GetAllAsync(null);
            return Ok(users);
        }

        [HttpDelete("delete")]
        [Authorize]
        public async Task<ActionResult<UserView>> DeleteUser([FromBody]long id)
        {
            try
            {
                await _userService.DeleteAsync(id);
                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<UserView>> GetUserTask()
        {
            var userId = _context.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var user = await _userService.GetByIdAsync(Convert.ToInt64(userId));
            if (user == null)
            {
                return NotFound();

            }

            return Ok(user);
        }

        [Authorize]
        [HttpPost("edit")]
        public async Task<ActionResult<UserView>> EditUserTask([FromBody]UserEdit newUserData)
        {
            var userNick = _context.HttpContext.User.FindFirst(ClaimTypes.Name).Value;
            try
            {
                var user = await _userService.EditUserInfoAsync(newUserData,userNick);
                return Ok(user);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [Authorize]
        [HttpPost("changePass")]
        public async Task<ActionResult<UserView>> ChangePasswordTask([FromBody] string password, string newPassword)
        {
            if (password != newPassword)
            {
                var userNick = _context.HttpContext.User.FindFirst(ClaimTypes.Name).Value;
                try
                {
                    var user = await _userService.ChangePassAsync(password, newPassword, userNick);
                    return Ok(user);
                }
                catch (Exception e)
                {
                    return BadRequest(e);
                }
            }
            else
            {
                return BadRequest("New password couldn't match with old'");
            }
        }
    }
}