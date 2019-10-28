using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Store.BL.Models;
using Store.BL.Services;

namespace Store.StoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly OrderService _orderService;
        private readonly IHttpContextAccessor _context;

        public OrderController(OrderService orderService, IHttpContextAccessor context)
        {
            _orderService = orderService;
            _context = context;
        }

        [HttpGet("orders")]
        [Authorize]
        public async Task<ActionResult<OrderView>> GetAllOrders()
        {
            var userId = _context.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var orders = await _orderService.GetAllAsync(x=>x.User.Id.Equals(Convert.ToInt64(userId)), order =>order.Items);
            return Ok(orders);
        }
    }
}