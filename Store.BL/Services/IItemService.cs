using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Store.BL.Models;
using Store.Entity.Models;

namespace Store.BL.Services
{
    public interface IItemService
    {
        Task<IList<ItemView>> GetAllAsync(Expression<Func<Item, bool>> expression, string[] includes);
        Task<Item> GetByIdAsync(long id);
        Task AddAsync(ItemView entity);
        Task DeleteAsync(ItemView entity);
        Task<Item> UpdateAsync(Item entity);
        Task<ItemView> EditItemAsync(ItemView entity);
    }
}
