using System;
using System.IO;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Store.BL.Exceptions;
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
        public async Task<ActionResult<UserView>> DeleteUser([FromBody]UserView user)
        {
            try
            {
                await _userService.DeleteAsync(user.Id);
                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        [HttpDelete("softDelete")]
        [Authorize]
        public async Task<ActionResult<UserView>> BlockUser([FromBody]UserView user)
        {
            try
            {
                await _userService.BlockAsync(user.Id);
                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        [HttpDelete("unlock")]
        [Authorize]
        public async Task<ActionResult<UserView>> UnlockUser([FromBody]UserView user)
        {
            try
            {
                await _userService.UnlockAsync(user.Id);
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
                var user = await _userService.EditUserInfoAsync(newUserData, userNick);
                return Ok(user);
            }
            catch (UserDoesNotExistException e)
            {
                return BadRequest(new {e.Message});
            }
            catch (Exception e)
            {
                return Conflict(new {e.Message});
            }
        }

        [Authorize]
        [HttpPost("changePass")]
        public async Task<ActionResult<UserView>> ChangePasswordTask([FromBody] Passwords passwords)
        {
            if (passwords.Password != passwords.NewPassword)
            {
                var userNick = _context.HttpContext.User.FindFirst(ClaimTypes.Name).Value;
                try
                {
                    var user = await _userService.ChangePassAsync(passwords.Password, passwords.NewPassword, userNick);
                    return Ok(user);
                }
                catch (InvalidDataException e)
                {
                    return BadRequest(new {e.Message});
                }
            }
            else
            {
                return BadRequest("New password couldn't match with old'");
            }
        }
    }
}