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
        Task<IList<ItemView>> GetAllAsync(Expression<Func<Item, bool>> expression = null, params Expression<Func<Item, object>>[] includes);
        Task<Item> GetByIdAsync(long id);
        Task AddAsync(ItemEditDto entity);
        Task DeleteAsync(ItemView entity);
        Task<Item> UpdateAsync(Item entity);
        Task<ItemView> EditItemAsync(ItemEditDto entity);

        Task<IList<TypeView>> GetTypesAsync(Expression<Func<ItemType, bool>> expression = null);
        Task<IList<CategoryView>> GetCategoriesAsync(Expression<Func<ItemCategory, bool>> expression = null);
    }
}
