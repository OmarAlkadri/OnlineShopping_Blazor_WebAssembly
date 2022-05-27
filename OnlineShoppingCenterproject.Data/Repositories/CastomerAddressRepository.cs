using Microsoft.EntityFrameworkCore;
using OnlineShoppingCenterproject.Core.Dto.AddresssDto;
using OnlineShoppingCenterproject.Core.Dto.CastomersDto;
using OnlineShoppingCenterproject.Core.Dto.UsersDto;
using OnlineShoppingCenterproject.Core.Entities;
using OnlineShoppingCenterproject.Core.Interfaces;
using OnlineShoppingCenterproject.Data_DB;

namespace OnlineShoppingCenterproject.Data.Repositories
{
    public class CastomerAddressRepository : RepositoryBase<CastomerAddress>, ICastomerAddressRepository
    {
        public CastomerAddressRepository(Context_DB Context) : base(Context)
        {

        }
        public async Task<List<CastomerAddress>> GetAllCastomer_Address(string userName)
        {
            var b = await (from castomer_Address in Context.CastomerAddress
                           join address in Context.Address on castomer_Address.AddressId equals address.Id
                           join castomer in Context.Castomer on castomer_Address.CastomerId equals castomer.Id
                           where castomer_Address.Castomer.UserName == userName
                           select new CastomerAddress
                           {
                               Id = castomer_Address.Id,
                               Title = castomer_Address.Title,
                               Address = new Address
                               {
                                   Id = address.Id,
                                   City = address.City,
                                   District = address.District,
                                   Neighborhood = address.Neighborhood,
                                   Title = address.Title,
                                   Phone = address.Phone

                               },
                           }).ToListAsync();
            return b;
        }

        public async Task<CastomerAddress> GetCastomer_AddressById(Guid Id)
        {
            var a = await (from castomer_Address in Context.CastomerAddress
                           join address in Context.Address on castomer_Address.AddressId equals address.Id
                           join castomer in Context.Castomer on castomer_Address.CastomerId equals castomer.Id
                           where castomer_Address.Id == Id
                           select new CastomerAddress
                           {
                               Id = castomer_Address.Id,
                               Title = castomer_Address.Title,
                               Address = new Address
                               {
                                   Id = address.Id,
                                   City = address.City,
                                   District = address.District,
                                   Neighborhood = address.Neighborhood,
                                   Title = address.Title,
                                   Phone = address.Phone
                               },
                               Castomer = new Castomer
                               {
                                   Id = castomer.Id,
                                  /* User = new User
                                   {
                                       Id = castomer.User.Id,
                                       Name = castomer.User.Name,
                                       LastName = castomer.User.LastName,
                                       Email = castomer.User.Email,
                                       Gender = castomer.User.Gender,
                                       Password = castomer.User.Password
                                   }*/
                               },
                           }).FirstOrDefaultAsync();
            return a;
        }
        public void CreateCastomer_Address(CastomerAddress entity)
        {
            Add(entity);
        }
        public void UpdateCastomer_Address(CastomerAddress entity)
        {
            Update(entity);
        }
        public void DeleteCastomer_Address(CastomerAddress entity)
        {
            Delete(entity);
        }
    }
}
