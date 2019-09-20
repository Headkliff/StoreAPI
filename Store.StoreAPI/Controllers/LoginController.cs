﻿using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Store.BL.Models;
using Store.BL.Services;

namespace Store.StoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly IUserService _userService;

        public LoginController(IConfiguration config, IUserService userService)
        {
            _config = config;
            this._userService = userService;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult CreateToken(Login login)
        {
            var user = Authenticate(login);

            if (user != null)
            {
                var tokenString = BuildToken();
                return Ok(new { token = tokenString });
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

        private UserView Authenticate(Login login)
        {
            UserView user = _userService.GetUserAuthAsync(login.Nickname,login.Password).Result;

            return user;
        }
    }
}