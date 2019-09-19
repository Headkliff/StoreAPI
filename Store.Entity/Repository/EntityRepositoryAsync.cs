﻿using System;
using System.Diagnostics;
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

        public async Task<IQueryable<T>> GetAllAsync()
        {
            return await Task.Run(() => _dbSet.AsQueryable());
        }

        public async Task<T> GetByIdAsync(long id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<T> GetByParamAsync(Expression<Func<T, bool>> expression)
        {
            return await _dbSet.Where(expression).FirstOrDefaultAsync();
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