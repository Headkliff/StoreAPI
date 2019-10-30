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
        Task<ItemViewList> GetAllAsync(ItemQuery query, params Expression<Func<Item, object>>[] includes);

        Task<ItemView> GetByIdAsync(long id, params Expression<Func<Item, object>>[] includes);
        Task AddAsync(ItemCreateDto entity);
        Task DeleteAsync(long entity);
        Task<ItemView> UpdateAsync(Item entity);
        Task<ItemView> EditItemAsync(ItemEditDto entity);

        Task<IList<TypeView>> GetTypesAsync(Expression<Func<ItemType, bool>> expression = null);
        Task<IList<CategoryView>> GetCategoriesAsync(Expression<Func<ItemCategory, bool>> expression = null);
    }
}