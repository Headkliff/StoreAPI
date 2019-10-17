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
        Task<UserView> GetByIdAsync(long id);

        Task AddAsync(Register entity);
        Task DeleteAsync(long id);
        Task BlockAsync(long id);
        Task UnlockAsync(long id);
        Task<string> UpdateAsync(User entity);
        Task<UserAuthorizeDTO> AuthenticateAsync(Login login);
        Task<string> RegisterAsync(Register userRegister);
        Task<string> EditUserInfoAsync(UserEdit userEdit, string userNick);
        Task<string> ChangePassAsync(string password, string newPassword, string userNick);
    }
}
