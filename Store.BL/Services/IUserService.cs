using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Store.BL.Models;
using Store.Entity.Models;

namespace Store.BL.Services
{
    public interface IUserService
    {
        Task<IList<UserView>> GetAllAsync(Expression<Func<User, bool>> expression);
        Task<UserView> GetByIdAsync();

        Task AddAsync(Register entity);
        Task DeleteAsync(UserView entity);
        Task UpdateAsync(UserView entity);
        Task<string> AuthenticateAsync(Login login);
        Task<string> RegisterAsync(Register userRegister);
    }
}
