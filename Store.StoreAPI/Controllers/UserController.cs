using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Store.BL.Models;
using Store.BL.Services;
using Store.Entity.Models;
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
        public async Task<ActionResult<User>> GetUserTask()
        {
            var user = await _userService.GetByIdAsync();
            if (user == null)
            {
                return NotFound();

            }

            return Ok(user);
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<User>> EditUserTask(Register newUserData)
        {
            var user = await _userService.UpdateAsync(newUserData);
            return Ok(user);
        }
    }
}