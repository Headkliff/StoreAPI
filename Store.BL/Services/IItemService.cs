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
        Task<ItemView> GetByIdAsync(long id);
        Task AddAsync(ItemCreateDto entity);
        Task DeleteAsync(long entity);
        Task<ItemView> UpdateAsync(Item entity);
        Task<ItemView> EditItemAsync(ItemEditDto entity);

        Task<IList<TypeView>> GetTypesAsync(Expression<Func<ItemType, bool>> expression = null);
        Task<IList<CategoryView>> GetCategoriesAsync(Expression<Func<ItemCategory, bool>> expression = null);
    }
}
