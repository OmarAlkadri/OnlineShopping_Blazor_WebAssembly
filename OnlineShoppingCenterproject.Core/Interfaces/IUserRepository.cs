using OnlineShoppingCenterproject.Core.Dto.UsersDto;
using OnlineShoppingCenterproject.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoppingCenterproject.Core.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        Task<IEnumerable<User>> GetAllUser();
        Task<User> GetUserById(Guid UserId);
        Task<Boolean> CheckEmail(string Email);
        Task<User> GetLogInUser(string Email, string password, string type);
        Task<User> DeleteCastomerByUser(Guid CastomerId);
        Task<User> DeleteCompanyByUser(Guid CompanyId);
        void CreateUser(User user);
        void UpdateUser(User user);
        void DeleteUser(User user);
    }
}
