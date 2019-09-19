using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Store.StoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : Controller
    {
        [Authorize]
        [Route("getLogin")]
        public IActionResult GetLogin()
        {
            return Ok($"Your Login: {User.Identities.GetEnumerator().Current?.Name}");
        }

        [Authorize(Roles = "admin")]
        [Route("getRole")]
        public IActionResult GetRole()
        {
            return Ok("Your role: administrator");
        }
    }
}