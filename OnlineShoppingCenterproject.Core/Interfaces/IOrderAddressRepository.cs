using OnlineShoppingCenterproject.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoppingCenterproject.Core.Interfaces
{
    public interface IOrderAddressRepository : IRepository<OrderAddress>
    {
        Task<IEnumerable<OrderAddress>> GetAllOrderAddress();
        Task<OrderAddress> GetOrderAddressId(Guid UserId);
        void CreateOrderAddress(OrderAddress entity);
        void UpdateOrderAddress(OrderAddress entity);
    }
}
