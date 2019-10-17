using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Store.BL.Exceptions;
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
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login(Login login)
        {
            try
            {
                var result = await _userService.AuthenticateAsync(login);
                return Ok(result);
            }
            catch (BlockedUserException e)
            {
                return Unauthorized(new {e.Message});
            }
            catch (UserDoesNotExistException e)
            {
                return Unauthorized(new {e.Message});
            }
            catch (InvalidDataException e)
            {
                return Unauthorized(new {e.Message});
            }
        }

        [AllowAnonymous]
        [HttpPost("registration")]
        public async Task<IActionResult> CreateToken(Register userRegister)
        {
            try
            {
                var token = await _userService.RegisterAsync(userRegister);
                return Ok(token);
            }
            catch (UserExistException e)
            {
                return BadRequest(new {e.Message});
            }
        }
    }
}