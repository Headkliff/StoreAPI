using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Store.BL.Models;
using Store.Entity.Models;
using Store.Entity.Repository;

namespace Store.BL.Services
{
    public class UserService : IUserService
    {
        private readonly IRepositoryAsync<User> _repository;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public UserService(IRepositoryAsync<User> repository, IMapper mapper, IConfiguration configuration)
        {
            _repository = repository;
            _mapper = mapper;
            _configuration = configuration;
        }

        public async Task<List<UserView>> GetAllAsync(Expression<Func<User, bool>> expression)
        {
            var users = await _repository.GetAllAsync(expression);
            return _mapper.Map<List<UserView>>(users);
        }

        public async Task<UserView> GetByIdAsync(long id)
        {
            var user = await _repository.GetByIdAsync(id);
            return _mapper.Map<UserView>(user);
        }

        public async Task AddAsync(Register entity)
        {
            var user = await _repository.GetAllAsync(x => x.Nickname.Equals(entity.Nickname, StringComparison.OrdinalIgnoreCase));
            if (user.Count!=0)
            {
                throw new Exception("this userView already exist");
            }
            User newUser = new User
            {
                Nickname = entity.Nickname, Password = entity.Password, FirstName = entity.FirstName,
                SecondName = entity.SecondName, Email = entity.Email
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

        public async Task<string> BuildToken(UserView user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var identity = await GetIdentity(user);

            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Issuer"],
                claims: identity.Claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<UserView> AuthenticateAsync(Login login)
        {
            var users = await GetAllAsync(x=>x.Nickname.Equals(login.Nickname) && x.Password.Equals(login.Password));

            return users.First();
        }

        public async Task<UserView> RegisterAsync(Register userRegister)
        {
            await AddAsync(userRegister);
            var users = await GetAllAsync(x=>x.Nickname.Equals(userRegister.Nickname) && x.Password.Equals(userRegister.Password));
            if (users.Count != 0)
                return users.First();
            return null;
        }

        private async Task<ClaimsIdentity> GetIdentity(UserView userView)
        {
            var users = await GetAllAsync(x=>x.Nickname.Equals(userView.Nickname));
            if (users.Count != 0)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, users.First().Nickname),
                };
                ClaimsIdentity claimsIdentity =
                    new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                        ClaimsIdentity.DefaultRoleClaimType);
                return claimsIdentity;
            }

            return null;
        }
    }
}