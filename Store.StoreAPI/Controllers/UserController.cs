using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Store.Entity.Db;
using Store.Entity.Models;

namespace Store.StoreAPI.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly ApplicationContext _context;

        public UserController(ApplicationContext context)
        {
            _context = context;

            if (!_context.Users.Any())
            {
                _context.Users.Add(new User { id = Guid.NewGuid(), Nickname = "test1", Password = "test1", FirstName = "test1", SecondName = "test1"});
                _context.SaveChanges();
            }
        }

        // GET: api/User
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUserTask()
        {
            return await _context.Users.ToListAsync();
        }

        // GET: api/User/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUserTask(Guid id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }
    }
}
