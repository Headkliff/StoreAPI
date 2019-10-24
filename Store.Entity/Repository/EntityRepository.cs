﻿using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Store.Entity.Db;
using Store.Entity.Models;

namespace Store.Entity.Repository
{
    public class EntityRepository<T> : IRepository<T> where T : EntityBase
    {
        private readonly ApplicationContext _context;
        private readonly DbSet<T> _dbSet;

        public EntityRepository(ApplicationContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task<IQueryable<T>> GetAllAsync(Expression<Func<T, bool>> expression = null, params Expression<Func<T, object>>[] includes)
        {
            return  includes.Aggregate(await Task.Run(() => (expression != null ? _dbSet.Where(expression) : _dbSet)),
                (current, includeProperty) => current.Include(includeProperty));
        }

        public async Task<T> GetByIdAsync(long id, params Expression<Func<T, object>>[] includes)
        {
            return  includes.Aggregate(await Task.Run(() => (_dbSet.Where(x=>x.Id.Equals(id)))),
                (current, includeProperty) => current.Include(includeProperty)).FirstOrDefault(); 
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