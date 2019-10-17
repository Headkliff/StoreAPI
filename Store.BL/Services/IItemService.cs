using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Store.Entity.Models;

namespace Store.BL.Services
{
    public interface IItemService
    {
        Task<IList<Item>> GetAllAsync(Expression<Func<Item, bool>> expression);
        Task<Item> GetByIdAsync(long id);
        Task AddAsync(Item entity);
        Task DeleteAsync(long id);
        Task<Item> UpdateAsync(Item entity);
    }
}
