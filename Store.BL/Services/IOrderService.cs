using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Store.BL.Models;
using Store.Entity.Models;

namespace Store.BL.Services
{
    public interface IOrderService
    {
        Task<IList<OrderView>> GetAllAsync(Expression<Func<Order, bool>> expression = null, params Expression<Func<Order, object>>[] includes);
        Task<Order> GetByIdAsync(long id);
        Task AddAsync(OrderView entity);
        Task DeleteAsync(long entity);
        Task<OrderView> UpdateAsync(OrderView entity);
        Task<OrderView> EditOrderAsync(OrderView entity);
    }
}
