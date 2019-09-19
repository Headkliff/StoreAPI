using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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

        // GET: api/User
        [HttpGet]
        //[Authorize]
        public async Task<ActionResult<IEnumerable<User>>> GetUserTask()
        {
            var currentUser = HttpContext.User;
            return Ok(await _userService.GetAllAsync());
        }

        // GET: api/User/5
        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<User>> GetUserTask(long id)
        {
            var currentUser = HttpContext.User;
            var user = await _userService.GetByIdAsync(id);

            if (user == null)
            {
                return NotFound();

            }

            return Ok(user);
        }
    }
}