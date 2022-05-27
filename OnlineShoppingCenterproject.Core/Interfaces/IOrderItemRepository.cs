using OnlineShoppingCenterproject.Core.Dto;
using OnlineShoppingCenterproject.Core.Dto.OrdersDto;
using OnlineShoppingCenterproject.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoppingCenterproject.Core.Interfaces
{
    public interface IOrderItemRepository : IRepository<OrderItem>
    {
        Task<List<OrderDto>> GetAllOrderItem(string? status);
        Task<List<OrderDto>> GetOrderItemsByOrderStatus(string status, Guid OrderId);
        Task<OrderDto> GetOrderItemById(Guid Id);
        Task<List<OrderDto>> GetOrderItemByCompany(Guid CompanyId);
        Task<List<OrderDto>> GetOrderItemByCastomer(Guid CastomerId);
        Task<List<OrderDto>> GetOrderItemByOrder(Guid OrderId);
        void CreateOrderItem(OrderItem entity);
        void UpdateOrderItem(OrderItem entity);
        void DeleteOrderItem(OrderItem entity);
    }
}
