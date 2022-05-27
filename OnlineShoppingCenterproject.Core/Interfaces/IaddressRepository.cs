using OnlineShoppingCenterproject.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoppingCenterproject.Core.Interfaces
{
    public interface IaddressRepository : IRepository<Address>
    {
        void UpdateAddress(Address entity);
        void DeleteAddress(Address entity);
    }
}
