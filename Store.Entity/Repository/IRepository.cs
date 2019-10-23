using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Store.Entity.Repository
{
    public interface IRepository<T> where T: Models.EntityBase
    {
        Task<IQueryable<T>> GetAllAsync(Expression<Func<T, bool>> expression, params Expression<Func<T, object>>[] includes);
        Task<T> GetByIdAsync(long id);

        Task AddAsync(T entity);
        Task DeleteAsync(T entity);
        Task UpdateAsync(T entity);


    }
}
