using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using Store.Entity.Models;
using Store.Entity.Repository;

namespace Store.BL.Services
{
    public class ItemService :IItemService
    {
        private readonly IRepository<Item> _repository;
        private readonly IConfiguration _configuration;

        public ItemService(IConfiguration configuration, IRepository<Item> repository)
        {
            _configuration = configuration;
            _repository = repository;
        }


        public async Task<IList<Item>> GetAllAsync(Expression<Func<Item, bool>> expression)
        {
            var items = await _repository.GetAllAsync(expression);
            return items.ToList();
        }

        public async Task<Item> GetByIdAsync(long id)
        {
            var item = await _repository.GetByIdAsync(id);
            return item;
        }

        public Task AddAsync(Item entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<Item> UpdateAsync(Item entity)
        {
            throw new NotImplementedException();
        }
    }
}
