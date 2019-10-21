using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Store.BL.Exceptions;
using Store.BL.Models;
using Store.BL.Services;

namespace Store.StoreAPI.Controllers
{
    [Route("api/[controller]"), ApiController]
    public class ItemController : ControllerBase
    {
        private readonly IItemService _itemService;

        public ItemController(IItemService itemService)
        {
            _itemService = itemService;
        }

        [HttpGet("items"), AllowAnonymous]
        public async Task<ActionResult<ItemView>> GetAllItems()
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
        public async Task<ActionResult<ItemView>> GetItemTask(long id)
        {
            var item = await _itemService.GetByIdAsync(id);
            if (item == null)
            {
                return NotFound();
            }

            return Ok(item);
        }

        [HttpPost("edit"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<ItemView>> EditItem(ItemView newItemInfo)
        {
            try
            {
                var item = await _itemService.EditItemAsync(newItemInfo);
                return Ok(item);
            }
            catch (ItemDoseNotExistException e)
            {
                return BadRequest(new {e.Message});
            }
            catch (Exception e)
            {
                return BadRequest(new { e.Message });
            }
            
        }

        [HttpPost("delete"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<ItemView>> DeleteItem(ItemView itemView)
        {
            try
            {
                await _itemService.DeleteAsync(itemView);
                return Ok();
            }
            catch (ItemDoseNotExistException e)
            {
                return BadRequest(new { e.Message });
            }
            catch (Exception e)
            {
                return BadRequest(new { e.Message });
            }

        }

        [HttpPost("create"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<ItemView>> AddItem(ItemView itemView)
        {
            try
            {
                await _itemService.AddAsync(itemView);
                return Ok();
            }
            catch (ItemDoseNotExistException e)
            {
                return BadRequest(new { e.Message });
            }
            catch (Exception e)
            {
                return BadRequest(new { e.Message });
            }

        }
    }
}