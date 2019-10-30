﻿using System;
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
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IHttpContextAccessor _context;

        public UserController(IUserService userService, IHttpContextAccessor context)
        {
            _userService = userService;
            _context = context;
        }

        [HttpPost("userList")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<UserView>> GetAllUsers(UserQuery query)
        {
            var users = await _userService.GetAllAsync(user=>user.Nickname.Contains(query.Nickname.Trim())&&user.Email.Contains(query.Email.Trim()), query.PageNumber);
            return Ok(users);
        }

        [HttpDelete("delete")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<UserView>> DeleteUser([FromBody]UserView user)
        {
            try
            {
                await _userService.DeleteAsync(user.Id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("softDelete")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<UserView>> BlockUser([FromBody]UserView user)
        {
            try
            {
                await _userService.BlockAsync(user.Id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("unlock")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<UserView>> UnlockUser([FromBody]UserView user)
        {
            try
            {
                await _userService.UnlockAsync(user.Id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
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
                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                return Conflict(e.Message);
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