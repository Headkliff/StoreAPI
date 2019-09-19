﻿using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Store.Entity.Repository
{
    public interface IRepositoryAsync<T> where T: Models.EntityBase
    {
        Task<IQueryable<T>> GetAllAsync();
        Task<T> GetByIdAsync(long id);
        Task<T> GetByParamAsync(Expression<Func<T, bool>> expression);

        Task AddAsync(T entity);
        Task DeleteAsync(T entity);
        Task UpdateAsync(T entity);


    }
}