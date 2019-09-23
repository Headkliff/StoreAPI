using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Store.Entity.Db;
using Store.Entity.Models;

namespace Store.Entity.Repository
{
    public class EntityRepositoryAsync<T> : IRepositoryAsync<T> where T : EntityBase
    {
        private readonly ApplicationContext _context;
        private readonly DbSet<T> _dbSet;

        public EntityRepositoryAsync(ApplicationContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();

        }

        public async Task<IList<T>> GetAllAsync(Expression<Func<T, bool>> expression)
        {
            return await _dbSet.Where(expression).ToListAsync();
        }

        public async Task<T> GetByIdAsync(long id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _context.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
