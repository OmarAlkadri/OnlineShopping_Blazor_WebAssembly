using OnlineShoppingCenterproject.Core.Entities;
using OnlineShoppingCenterproject.Core.Interfaces;
using OnlineShoppingCenterproject.Data_DB;
using Microsoft.EntityFrameworkCore;
using OnlineShoppingCenterproject.Core.Dto.UsersDto;

namespace OnlineShoppingCenterproject.Data.Repositories
{

    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        protected Context_DB Context { get; set; }
        public UserRepository(Context_DB Context) : base(Context)
        {
            this.Context = Context;
        }

        public async Task<User> GetLogInUser(string Email, string password, string type)
        {
            var user = await Context.User.SingleOrDefaultAsync(f => f.Email == Email && f.Password == password);
            if (user == null)
            {
                return null;
            }
            return user;
            /*  UserType a = new UserType(type);
              if (type == "Castomer")
              {
                  var Castomer = await Context.Castomer.SingleOrDefaultAsync(f => f.Userid  == user.Id);
                  if (Castomer != null)
                  {
                      a.Castomer = Castomer;
                      return a;
                  }
              }
              else if (type == "Company")
              {
                  var Company = await Context.Company.SingleOrDefaultAsync(f => f.Userid  == user.Id);
                  if (Company != null)
                  {
                      a.Company = Company;
                      return a;
                  }    
              }
              a.User = user;
              return a;*/
        }
        public void CreateUser(User user)
        {
            Add(user);
        }
        public void DeleteUser(User user)
        {
            Delete(user);
        }

        public async Task<IEnumerable<User>> GetAllUser()
        {
            return await (from data in Context.User
                          select data).ToListAsync();
        }

        public async Task<User> GetUserById(Guid customerId)
        {
            var a = await (from user in Context.User
                               // join customer in Context.Castomer on user.Id equals customer.Userid 
                               //     where customer.Id == customerId
                           select new User
                           {
                               Id = user.Id,
                               Name = user.Name,
                               LastName = user.LastName,
                               Email = user.Email,
                               Gender = user.Gender,
                               Password = user.Password
                           }).FirstAsync();

            return a;
        }
        public async Task<User> DeleteCastomerByUser(Guid customerId)
        {
            return await (from user in Context.User
                              //      join customer in Context.Castomer on user.Id equals customer.Userid 
                              //        where customer.Id == customerId
                          select user).FirstAsync();
        }

        public async Task<User> DeleteCompanyByUser(Guid CompanyId)
        {
            return await (from user in Context.User
                              //     join Company in Context.Company on user.Id equals Company.Userid 
                              //   where Company.Id == CompanyId
                          select new User
                          {
                              Id = user.Id
                          }).FirstAsync();
        }
        public void UpdateUser(User user)
        {
            Update(user);
        }
        public async Task<bool> CheckEmail(string Email)
        {
            var emailList = await Context.User.Where(f => f.Email == Email).ToListAsync();
            if (emailList.Count >= 1)
            {
                return false;
            }
            return true;
        }
    }
}
