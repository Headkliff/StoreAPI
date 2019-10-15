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
        Task<UserView> GetByIdAsync(long toInt64);

        Task AddAsync(Register entity);
        Task DeleteAsync(long id);
        Task SoftDeleteAsync(long id);
        Task<string> UpdateAsync(User entity);
        Task<string> AuthenticateAsync(Login login);
        Task<string> RegisterAsync(Register userRegister);
        Task<string> EditUserInfoAsync(UserEdit userEdit, string userNick);
        Task<string> ChangePassAsync(string password, string newPassword, string userNick);
    }
}
