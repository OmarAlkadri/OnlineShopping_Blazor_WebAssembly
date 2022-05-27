using OnlineShoppingCenterproject.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoppingCenterproject.Core.Interfaces
{
   public interface IOrderRepository : IRepository<Order>
    {
        Task<IEnumerable<Order>> GetAllOrder(string userName);
        Task<Order> GetOrderById(Guid Id);
        Task<Order> DeleteOrderById(Guid OrderId);
        void CreateOrder(Order entity);
        void UpdateOrder(Order entity);
        void DeleteOrder(Order entity);
    }
}
