using Microsoft.EntityFrameworkCore;
using OnlineShoppingCenterproject.Core.Dto;
using OnlineShoppingCenterproject.Core.Entities;
using OnlineShoppingCenterproject.Core.Interfaces;
using OnlineShoppingCenterproject.Data_DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoppingCenterproject.Data.Repositories
{
    public class CastomerRepository : RepositoryBase<Castomer>, ICastomerRepository
    {
        public CastomerRepository(Context_DB Context) : base(Context)
        {

        }
        public async Task<IEnumerable<Castomer>> GetAllCastomer()
        {
            var b = await (from cas in Context.Castomer
                           select new Castomer
                           {
                               Id = cas.Id,
                               UserName = cas.UserName,
                               User = new User
                               {
                                   Id = cas.User.Id,
                                   Name = cas.User.Name,
                                   LastName = cas.User.LastName,
                                   Email = cas.User.Email,
                                   Gender = cas.User.Gender,
                                   UserName = cas.User.UserName,
                                   Password = cas.User.Password
                               },
                           }).ToListAsync();
            return b;
        }

        public async Task<Castomer> GetCastomerByUserName(string userName)
        {
            var castomer = await (from cas in Context.Castomer
                                  where cas.UserName == userName
                                  select new Castomer
                                  {
                                      Id = cas.Id,
                                      UserName = cas.UserName,
                                      User = new User
                                      {
                                          Id = cas.User.Id,
                                          Name = cas.User.Name,
                                          LastName = cas.User.LastName,
                                          Email = cas.User.Email,
                                          Gender = cas.User.Gender,
                                          UserName = cas.User.UserName,
                                          Password = cas.User.Password
                                      },
                                  }).FirstOrDefaultAsync();
            return castomer;
        }
        public void CreateCastomer(Castomer entity)
        {
            Add(entity);
        }
        public void UpdateCastomer(Castomer entity)
        {
            Update(entity);
        }
        public void DeleteCastomer(Castomer entity)
        {
            Delete(entity);
        }
    }
}
