using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Store.BL.Models;
using Store.Entity.Models;
using Store.Entity.Repository;

namespace Store.BL.Services
{
    public class OrderService : IOrderService
    {
        private readonly IRepository<Order> _repository;
        private readonly IMapper _mapper;

        public OrderService(IRepository<Order> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IList<OrderView>> GetAllAsync(Expression<Func<Order, bool>> expression = null,
            params Expression<Func<Order, object>>[] includes)
        {
            return _mapper.Map<IList<OrderView>>(await _repository.GetAllAsync(expression, includes));
        }

        public async Task<Order> GetByIdAsync(long id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public Task AddAsync(OrderView entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(long entity)
        {
            throw new NotImplementedException();
        }

        public Task<OrderView> UpdateAsync(OrderView entity)
        {
            throw new NotImplementedException();
        }

        public Task<OrderView> EditOrderAsync(OrderView entity)
        {
            throw new NotImplementedException();
        }
    }
}