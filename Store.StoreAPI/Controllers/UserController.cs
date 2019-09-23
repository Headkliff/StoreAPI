using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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

        // GET: api/User/5
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
    }
}