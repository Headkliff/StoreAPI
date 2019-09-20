using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Store.BL.Models;
using Store.BL.Services;
using Store.Entity.Models;

namespace Store.StoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;
        private readonly IUserService _userService;

        public RegisterController(IUserService userService, IConfiguration config, IMapper mapper)
        {
            _userService = userService;
            _config = config;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> CreateToken(Register userRegister)
        {
            try 
            {
                var user = await Register(userRegister);

                if (user != null)
                {
                    var tokenString = BuildToken();
                    return Ok(new { token = tokenString });
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            

            return Unauthorized();
        }

        private string BuildToken()
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                _config["Jwt:Issuer"],
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private async Task<UserView> Register(Register userRegister)
        {
            
            await _userService.AddAsync(userRegister);
            var user = await _userService.GetUserAuthAsync(userRegister.Nickname, userRegister.Password);
            return user;
        }
    }
}