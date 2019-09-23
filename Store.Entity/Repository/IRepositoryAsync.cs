﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Store.Entity.Repository
{
    public interface IRepositoryAsync<T> where T: Models.EntityBase
    {
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>> expression);
        Task<T> GetByIdAsync(long id);

        Task AddAsync(T entity);
        Task DeleteAsync(T entity);
        Task UpdateAsync(T entity);


    }
}
