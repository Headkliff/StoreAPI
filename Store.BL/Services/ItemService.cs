using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using Store.BL.Exceptions;
using Store.BL.Models;
using Store.Entity.Models;
using Store.Entity.Repository;

namespace Store.BL.Services
{
    public class ItemService : IItemService
    {
        private readonly IRepository<Item> _repository;
        private readonly IMapper _mapper;
        private readonly IRepository<ItemType> _typeRepository;
        private readonly IRepository<ItemCategory> _categoryRepository;

        public ItemService(IRepository<Item> repository, IMapper mapper, IRepository<ItemType> typeRepository,
            IRepository<ItemCategory> categoryRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _typeRepository = typeRepository;
            _categoryRepository = categoryRepository;
        }


        public async Task<IList<ItemView>> GetAllAsync(Expression<Func<Item, bool>> expression = null,
            params Expression<Func<Item, object>>[] includes)
        {
            var items = (await _repository.GetAllAsync(expression, includes));
            return _mapper.Map<IList<ItemView>>(items);
        }

        public async Task<Item> GetByIdAsync(long id)
        {
            var item = await _repository.GetByIdAsync(id);
            return item;
        }

        public async Task AddAsync(ItemEditDto entity)
        {
            var item = (await _repository.GetAllAsync(x =>
                x.Name.Equals(entity.Name.Trim(), StringComparison.OrdinalIgnoreCase))).FirstOrDefault();
            if (item != null)
            {
                throw new ItemExistException("This Item already exist");
            }

            var newItem = new Item
            {
                Name = entity.Name.Trim(),
                Category = (await _categoryRepository.GetAllAsync(x =>
                    x.Name.Equals(entity.CategoryName, StringComparison.OrdinalIgnoreCase))).FirstOrDefault(),
                Type = (await _typeRepository.GetAllAsync(x =>
                    x.Name.Equals(entity.TypeName, StringComparison.OrdinalIgnoreCase))).FirstOrDefault(),
                Cost = entity.Cost
            };
            await _repository.AddAsync(newItem);
        }

        public async Task DeleteAsync(ItemView item)
        {
            var entity = await _repository.GetByIdAsync(item.Id);
            if (entity != null)
            {
                await _repository.DeleteAsync(entity: entity);
            }
        }

        public async Task<Item> UpdateAsync(Item entity)
        {
            try
            {
                await _repository.UpdateAsync(entity);
            }
            catch (Exception)
            {
                throw new Exception("Something went wrong");
            }

            return await GetByIdAsync(entity.Id);
        }

        public async Task<ItemView> EditItemAsync(ItemEditDto entry)
        {
            var item = (await _repository.GetAllAsync(x => x.Id.Equals(entry.Id), item1 => item1.Type))
                .FirstOrDefault();
            var type = (await _typeRepository.GetAllAsync(x =>
                x.Name.Equals(entry.TypeName, StringComparison.OrdinalIgnoreCase))).FirstOrDefault();

            if (item != null)
            {
                //item.ItemCategoryId = entry.CategoryName;
                item.Type = type;
                item.Name = entry.Name.Trim();
                item.Cost = entry.Cost;
                return _mapper.Map<ItemView>(await UpdateAsync(item));
            }
            else
            {
                throw new ItemDoseNotExistException("Item doesn't exist");
            }
        }
    }
}