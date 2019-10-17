using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Store.BL.Services;
using Store.Entity.Models;

namespace Store.StoreAPI.Controllers
{
    [Route("api/[controller]"), ApiController]
    public class ItemController : Controller
    {
        private readonly IItemService _itemService;

        public ItemController(IItemService itemService)
        {
            _itemService = itemService;
        }

        [HttpGet("items"), AllowAnonymous]
        public async Task<ActionResult<Item>> GetAllItems()
        {
            try
            {
                var items = await _itemService.GetAllAsync(null);
                return Ok(items);
            }
            catch (Exception e)
            {
                return BadRequest(new {e.Message});
            }
        }

        [HttpGet("{id}"), AllowAnonymous]
        public async Task<ActionResult<Item>> GetItemTask(long id)
        {
            var item = await _itemService.GetByIdAsync(id);
            if (item == null)
            {
                return NotFound();
            }

            return Ok(item);
        }
    }
}