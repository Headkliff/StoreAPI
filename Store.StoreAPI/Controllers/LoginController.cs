using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Store.BL.Models;
using Store.BL.Services;

namespace Store.StoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUserService _userService;

        public LoginController(IUserService userService)
        {
            this._userService = userService;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(Login login)
        {
            var user =await _userService.AuthenticateAsync(login);

            if (user != null)
            {
                return Ok(new { token = await _userService.BuildToken(user)});
            }

            return Unauthorized();
        }
    }
}