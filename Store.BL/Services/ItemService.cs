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


        public async Task<ItemViewList> GetAllAsync(ItemQuery query,
            params Expression<Func<Item, object>>[] includes)
        {
            var name = query.Name.Trim();
            var items = (await _repository.GetAllAsync(x => x.Name.Contains(name, StringComparison.OrdinalIgnoreCase) &&
                                                            x.Category.Name.Contains(query.Category) &&
                                                            x.Type.Name.Contains(query.Type), includes));
            const int itemsOnPage = 9;

            switch (query.SelectedSort)
            {
                case "nameasc":
                    items = items.OrderBy(item => item.Name);
                    break;
                case "namedesc":
                    items = items.OrderByDescending(item => item.Name);
                    break;
                case "costasc":
                    items = items.OrderBy(item => item.Cost);
                    break;
                case "costdesc":
                    items = items.OrderByDescending(item => item.Cost);
                    break;
                case "DateAsc":
                    items = items.OrderBy(item => item.UpdateDateTime);
                    break;
                case "DateDesc":
                    items = items.OrderByDescending(item => item.UpdateDateTime);
                    break;
            }

            long count = items.Count();
            var itemsList = _mapper.Map<IList<ItemView>>(items.Skip(query.PageNumber * itemsOnPage).Take(itemsOnPage));
            ItemViewList itemViewList = new ItemViewList
            {
                Items = itemsList,
                Count = count
            };
            return itemViewList;
        }

        public async Task<ItemView> GetByIdAsync(long id, params Expression<Func<Item, object>>[] includes)
        {
            var item = await _repository.GetByIdAsync(id, includes);
            return _mapper.Map<ItemView>(item);
        }

        public async Task AddAsync(ItemCreateDto entity)
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

        public async Task DeleteAsync(long id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null)
            {
                throw new ItemDoseNotExistException("Item not fount");
            }

            await _repository.DeleteAsync(entity: entity);
        }

        public async Task<ItemView> UpdateAsync(Item entity)
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
            var item = (await _repository.GetByIdAsync(entry.Id, item1 => item1.Type, item1 => item1.Category));

            var type = (await _typeRepository.GetAllAsync(x =>
                x.Name.Equals(entry.TypeName, StringComparison.OrdinalIgnoreCase))).FirstOrDefault();
            var category = (await _categoryRepository.GetAllAsync(x =>
                x.Name.Equals(entry.CategoryName, StringComparison.OrdinalIgnoreCase))).FirstOrDefault();

            if (item != null)
            {
                item.Category = category;
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

        public async Task<IList<TypeView>> GetTypesAsync(Expression<Func<ItemType, bool>> expression = null)
        {
            var types = await _typeRepository.GetAllAsync(expression);

            return _mapper.Map<IList<TypeView>>(types);
        }

        public async Task<IList<CategoryView>> GetCategoriesAsync(
            Expression<Func<ItemCategory, bool>> expression = null)
        {
            var categories = await _categoryRepository.GetAllAsync(expression);

            return _mapper.Map<IList<CategoryView>>(categories);
        }
    }
}