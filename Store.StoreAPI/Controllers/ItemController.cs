using System;
using System.Linq;
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

        [HttpPost("items"), AllowAnonymous]
        public async Task<ActionResult> GetAllItems(ItemQuery query)
        {
            try
            {
                var items = await ((_itemService.GetAllAsync(query, item => item.Type,
                    item => item.Category)));

                return Ok(items);
            }
            catch (Exception e)
            {
                return BadRequest(new {e.Message});
            }
        }

        [HttpPost("sort"), AllowAnonymous]
        public async Task<ActionResult> GetByFilter(ItemQuery query)
        {
            try
            {
                var items = await _itemService.GetByFilter(query);
                return Ok(items);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [HttpGet("{id}"), AllowAnonymous]
        public async Task<ActionResult<ItemView>> GetItemTask(long id)
        {
            var item = await _itemService.GetByIdAsync(id, item1 => item1.Type, item1 => item1.Category);
            if (item == null)
            {
                return NotFound();
            }

            return Ok(item);
        }

        [HttpPost("edit"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<ItemView>> EditItem(ItemEditDto newItemInfo)
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
                return BadRequest(new {e.Message});
            }
        }

        [HttpDelete("delete"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<ItemView>> DeleteItem([FromBody] ItemView item)
        {
            try
            {
                await _itemService.DeleteAsync(item.Id);
                return Ok();
            }
            catch (ItemDoseNotExistException e)
            {
                return BadRequest(new {e.Message});
            }
            catch (Exception e)
            {
                return BadRequest(new {e.Message});
            }
        }

        [HttpPost("create"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<ItemView>> AddItem(ItemCreateDto itemEditDto)
        {
            try
            {
                await _itemService.AddAsync(itemEditDto);
                return Ok();
            }
            catch (ItemDoseNotExistException e)
            {
                return BadRequest(new {e.Message});
            }
            catch (Exception e)
            {
                return BadRequest(new {e.Message});
            }
        }

        [HttpGet("types"), AllowAnonymous]
        public async Task<ActionResult<TypeView>> GetAllTypes()
        {
            try
            {
                var types = await _itemService.GetTypesAsync();
                return Ok(types);
            }
            catch (Exception e)
            {
                return BadRequest(new {e.Message});
            }
        }

        [HttpGet("categories"), AllowAnonymous]
        public async Task<ActionResult<CategoryView>> GetCategories()
        {
            try
            {
                var categories = await _itemService.GetCategoriesAsync();
                return Ok(categories);
            }
            catch (Exception e)
            {
                return BadRequest(new {e.Message});
            }
        }
    }
}