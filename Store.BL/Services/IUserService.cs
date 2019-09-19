using System.Collections.Generic;
using System.Threading.Tasks;
using Store.BL.Models;

namespace Store.BL.Services
{
    public interface IUserService
    {
        Task<IEnumerable<UserView>> GetAllAsync();
        Task<UserView> GetByIdAsync(long id);
        Task<UserView> GetUserAuthAsync(string nickname, string password);

        Task AddAsync(UserView entity);
        Task DeleteAsync(UserView entity);
        Task UpdateAsync(UserView entity);
    }
}
