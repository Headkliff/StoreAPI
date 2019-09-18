using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Store.Entity.Db;
using Store.Entity.Models;
using Store.Entity.Repository;

namespace Store.StoreAPI.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IRepositoryAsync<User> _userRepositoryAsync;

        public UserController(IRepositoryAsync<User> userRepositoryAsync)
        {
            this._userRepositoryAsync = userRepositoryAsync;
        }


        // GET: api/User
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUserTask()
        {
            return Ok(await _userRepositoryAsync.GetAllAsync());
        }

        // GET: api/User/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUserTask(Guid id)
        {
            var user = await _userRepositoryAsync.GetByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }
    }
}
