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
        private readonly IRepository<User> _repository;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        

        public UserService(IRepository<User> repository, IMapper mapper, IConfiguration configuration)
        {
            _repository = repository;
            _mapper = mapper;
            _configuration = configuration;
        }

        public async Task<IList<UserView>> GetAllAsync(Expression<Func<User, bool>> expression)
        {
            var users = await _repository.GetAllAsync(expression);
            return _mapper.Map<IList<UserView>>(users);
        }

        public async Task<UserView> GetByIdAsync(long id)
        {
            var user = await _repository.GetByIdAsync(id);
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

            var newUser = new User
            {
                Nickname = entity.Nickname.Trim(), Password = BCrypt.Net.BCrypt.HashPassword(entity.Password),
                FirstName = entity.FirstName.Trim(),
                SecondName = entity.SecondName.Trim(), Email = entity.Email.Trim()
            };
            await _repository.AddAsync(newUser);
        }

        public async Task DeleteAsync(long id)
        {
            var user = await _repository.GetByIdAsync(id);
            if (user != null)
            {
                await _repository.DeleteAsync(entity: user);
            }
        }

        public async Task<string> UpdateAsync(User entity)
        {
            try
            {
                await _repository.UpdateAsync(entity);
            }
            catch (Exception)
            {
                throw new Exception("Something went wrong");
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
            if (users !=null)
            {
                var correct =BCrypt.Net.BCrypt.Verify(login.Password, users.FirstOrDefault()?.Password);
                if (correct)
                {
                    token = BuildToken(_mapper.Map<UserView>(users.FirstOrDefault()));
                    return token;

                }
                else
                {
                    throw new Exception("This data invalid");
                }
            }
            else
            {
                throw new Exception("This user doesn't' exist");
            }
        }

        public async Task<string> RegisterAsync(Register userRegister)
        {

            await AddAsync(userRegister);
            var users = await GetAllAsync(x =>
                x.Nickname.Equals(userRegister.Nickname.Trim(), StringComparison.OrdinalIgnoreCase));
            return BuildToken(users.FirstOrDefault());
        }

        private ClaimsIdentity GetIdentity(UserView userView)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, userView.Nickname),
                new Claim(ClaimTypes.NameIdentifier, userView.Id.ToString()),
                new Claim(ClaimTypes.Name, userView.Nickname)
            };
            ClaimsIdentity claimsIdentity =
                new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                    ClaimsIdentity.DefaultRoleClaimType);
            return claimsIdentity;
        }

        public async Task<string> EditUserInfoAsync(UserEdit userEdit, string userNick)
        {
            var user = (await _repository.GetAllAsync(x =>
                x.Nickname.Equals(userNick.Trim(), StringComparison.OrdinalIgnoreCase))).FirstOrDefault();
            if (user != null)
            {
                user.Email = userEdit.Email.Trim();
                user.FirstName = userEdit.FirstName.Trim();
                user.SecondName = userEdit.SecondName.Trim();

                return await UpdateAsync(user);
            }
            else
            {
                throw new Exception("This user don't' exist");
            }
        }

        public async Task<string> ChangePassAsync(string password , string newPassword, string userNick)
        {
            var user = (await _repository.GetAllAsync(x =>
                x.Nickname.Equals(userNick.Trim(), StringComparison.OrdinalIgnoreCase))).FirstOrDefault();
            if (user!=null && BCrypt.Net.BCrypt.Verify(password, user.Password))
            {
                user.Password = BCrypt.Net.BCrypt.HashPassword(newPassword);
                return await UpdateAsync(user);
            }
            else
            {
                throw new Exception("Invalid password");
            }
        }
    }
}