using OnlineShoppingCenterproject.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoppingCenterproject.Core.Interfaces
{
    public interface ICastomerAddressRepository : IRepository<CastomerAddress>
    {
        Task<List<CastomerAddress>> GetAllCastomer_Address(string userName);
        Task<CastomerAddress> GetCastomer_AddressById(Guid Id);
        void CreateCastomer_Address(CastomerAddress entity);
        void UpdateCastomer_Address(CastomerAddress entity);
        void DeleteCastomer_Address(CastomerAddress entity);
    }
}