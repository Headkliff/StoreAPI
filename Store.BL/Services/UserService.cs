using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Store.BL.Models;
using Store.Entity.Models;
using Store.Entity.Repository;

namespace Store.BL.Services
{
    public class UserService : IUserService
    {
        private readonly IRepositoryAsync<User> _repository;
        private readonly IMapper _mapper;

        public UserService(IRepositoryAsync<User> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserView>> GetAllAsync()
        {
            var users = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<UserView>>(users);
        }

        public async Task<UserView> GetByIdAsync(long id)
        {
            var user = await _repository.GetByIdAsync(id);
            return _mapper.Map<UserView>(user);
        }

        public async Task<UserView> GetUserAuthAsync(string nickname, string password)
        {
            var user = await _repository.GetByParamAsync(
                x => x.Nickname.Equals(nickname) && x.Password.Equals(password));
            return _mapper.Map<UserView>(user);
        }

        public async Task AddAsync(Register entity)
        {
            var user = await _repository.GetByParamAsync(x => x.Nickname.Equals(entity.Nickname, StringComparison.OrdinalIgnoreCase));
            if (user != null)
            {
                throw new Exception("this user already exist");
            }
            User newUser = new User
            {
                Nickname = entity.Nickname, Password = entity.Password, FirstName = entity.FirstName,
                SecondName = entity.SecondName
            };
            await _repository.AddAsync(newUser);
        }

        public Task DeleteAsync(UserView entity)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(UserView entity)
        {
            throw new NotImplementedException();
        }
    }
}