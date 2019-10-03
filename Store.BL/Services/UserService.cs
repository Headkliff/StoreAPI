using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
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
        private readonly IHttpContextAccessor _context;

        public UserService(IRepositoryAsync<User> repository, IMapper mapper, IConfiguration configuration,
            IHttpContextAccessor context)
        {
            _repository = repository;
            _mapper = mapper;
            _configuration = configuration;
            _context = context;
        }

        public async Task<IList<UserView>> GetAllAsync(Expression<Func<User, bool>> expression)
        {
            var users = await _repository.GetAllAsync(expression);
            return _mapper.Map<IList<UserView>>(users);
        }

        public async Task<UserView> GetByIdAsync()
        {
            var userId = _context.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var user = await _repository.GetByIdAsync(Convert.ToInt64(userId));
            return _mapper.Map<UserView>(user);
        }

        public async Task AddAsync(Register entity)
        {
            var user = (await _repository.GetAllAsync(x =>
                x.Nickname.Equals(entity.Nickname, StringComparison.OrdinalIgnoreCase))).FirstOrDefault();
            if (user != null)
            {
                throw new Exception("this userView already exist");
            }

            User newUser = new User
            {
                Nickname = entity.Nickname, Password = BCrypt.Net.BCrypt.HashPassword(entity.Password),
                FirstName = entity.FirstName,
                SecondName = entity.SecondName, Email = entity.Email
            };
            await _repository.AddAsync(newUser);
        }

        public Task DeleteAsync(UserView entity)
        {
            throw new NotImplementedException();
        }

        public async Task<string> UpdateAsync(Register entity)
        {
            try
            {
                await _repository.UpdateAsync(_mapper.Map<User>(entity));
            }
            catch (Exception)
            {
                throw new Exception("this Nickname already exist");
            }

            return BuildToken(
                (await GetAllAsync(x => x.Nickname.Equals(entity.Nickname, StringComparison.OrdinalIgnoreCase)))
                .FirstOrDefault());
        }

        private string BuildToken(UserView user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var identity = GetIdentity(user);

            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Issuer"],
                claims: identity.Claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<string> AuthenticateAsync(Login login)
        {
            var token = "";
            var users = await _repository.GetAllAsync(x => x.Nickname.Equals(login.Nickname, StringComparison.OrdinalIgnoreCase));
            try
            {
                var correct =
                    BCrypt.Net.BCrypt.Verify(login.Password, users.FirstOrDefault()?.Password);
                if (correct)
                {
                     token = BuildToken(_mapper.Map<UserView>(users.FirstOrDefault()));
                }
            }
            catch (Exception e)
            {
                throw new Exception("Invalid data");
            }

            return token;
        }

        public async Task<string> RegisterAsync(Register userRegister)
        {

            await AddAsync(userRegister);
            var users = await GetAllAsync(x =>
                x.Nickname.Equals(userRegister.Nickname, StringComparison.OrdinalIgnoreCase));
            return BuildToken(users.FirstOrDefault());
        }

        private ClaimsIdentity GetIdentity(UserView userView)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, userView.Nickname),
                new Claim(ClaimTypes.NameIdentifier, userView.Id.ToString())
            };
            ClaimsIdentity claimsIdentity =
                new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                    ClaimsIdentity.DefaultRoleClaimType);
            return claimsIdentity;
        }
    }
}