using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Store.BL.Models;
using Store.BL.Services;

namespace Store.StoreAPI.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }


        [HttpGet]
        [Authorize]
        public async Task<ActionResult<UserView>> GetUserTask()
        {
            var user = await _userService.GetByIdAsync();
            if (user == null)
            {
                return NotFound();

            }

            return Ok(user);
        }

        [HttpPost("edit")]
        [Authorize]
        public async Task<ActionResult<UserView>> EditUserTask(Register newUserData)
        {
            var user = await _userService.UpdateAsync(newUserData);
            return Ok(user);
        }
    }
}