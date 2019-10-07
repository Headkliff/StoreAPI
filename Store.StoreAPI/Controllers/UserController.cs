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
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IHttpContextAccessor _context;

        public UserController(IUserService userService, IHttpContextAccessor context)
        {
            _userService = userService;
            _context = context;
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
        public async Task<ActionResult<UserEdit>> EditUserTask([FromBody]UserEdit newUserData)
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
    }
}