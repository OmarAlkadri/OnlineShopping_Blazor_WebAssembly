using Microsoft.EntityFrameworkCore;
using OnlineShoppingCenterproject.Core.Dto;
using OnlineShoppingCenterproject.Core.Entities;
using OnlineShoppingCenterproject.Core.Interfaces;
using OnlineShoppingCenterproject.Core.Dto;
using OnlineShoppingCenterproject.Data_DB;
using OnlineShoppingCenterproject.Core.Dto.OrdersDto;
using OnlineShoppingCenterproject.Core.Dto.ProductCompanysDto;
using OnlineShoppingCenterproject.Core.Dto.CompanysDto;
using OnlineShoppingCenterproject.Core.Dto.CastomersDto;
using OnlineShoppingCenterproject.Core.Dto.UsersDto;

namespace OnlineShoppingCenterproject.Data.Repositories
{
    public class OrderItemRepository : RepositoryBase<OrderItem>, IOrderItemRepository
    {
        public OrderItemRepository(Context_DB Context) : base(Context)
        {
        }
        public async Task<List<OrderDto>> GetAllOrderItem(string? status)
        {
            if (status.ToLower() == "sold")
                return await (from orderItem in Context.OrderItem
                              join order in Context.Order on orderItem.OrderId equals order.Id
                              join product in Context.Product on orderItem.ProductId equals product.Id
                              where order.status == Status.Sold
                              select new OrderDto
                              {
                                  OrderItemId = orderItem.Id,
                                  Id = order.Id,
                                  OrderDate = order.OrderDate,
                                  Time = order.Time,
                                  total = order.total,
                                  status = order.status,
                                  Price = orderItem.Price,
                                  Quantity = orderItem.Quantity,
                                  Product = product
                              }).ToListAsync();
            else if (status.ToLower() == "inthebag")
                return await (from orderItem in Context.OrderItem
                              join order in Context.Order on orderItem.OrderId equals order.Id
                              join product in Context.Product on orderItem.ProductId equals product.Id
                              where order.status == Status.InTheBag
                              select new OrderDto
                              {
                                  OrderItemId = orderItem.Id,
                                  Id = order.Id,
                                  OrderDate = order.OrderDate,
                                  Time = order.Time,
                                  total = order.total,
                                  status = order.status,
                                  Price = orderItem.Price,
                                  Quantity = orderItem.Quantity,
                                  Product = product
                              }).ToListAsync();
            else if (status.ToLower() == "all")
                return await (from orderItem in Context.OrderItem
                              join order in Context.Order on orderItem.OrderId equals order.Id
                              join product in Context.Product on orderItem.ProductId equals product.Id
                              select new OrderDto
                              {
                                  OrderItemId = orderItem.Id,
                                  Id = order.Id,
                                  OrderDate = order.OrderDate,
                                  Time = order.Time,
                                  total = order.total,
                                  status = order.status,
                                  Price = orderItem.Price,
                                  Quantity = orderItem.Quantity,
                                  Product = product
                              }).ToListAsync();
            else
                return null;
        }

        public async Task<OrderDto> GetOrderItemById(Guid Id)
        {
            return await (from orderItem in Context.OrderItem
                          join order in Context.Order on orderItem.OrderId equals order.Id
                          join product in Context.Product on orderItem.ProductId equals product.Id
                          where orderItem.Id == Id
                          select new OrderDto
                          {
                              OrderItemId = orderItem.Id,
                              Id = order.Id,
                              OrderDate = order.OrderDate,
                              Time = order.Time,
                              total = order.total,
                              status = order.status,
                              Price = orderItem.Price,
                              Quantity = orderItem.Quantity,
                              Product = product
                          }).FirstAsync();
        }
        public async Task<List<OrderDto>> GetOrderItemsByOrderStatus(string status, Guid OrderId)
        {
            if (status.ToLower() == "sold")
                return await (from orderItem in Context.OrderItem
                              join order in Context.Order on orderItem.OrderId equals order.Id
                              join product in Context.Product on orderItem.ProductId equals product.Id
                              where order.Id == OrderId && order.status == Status.Sold
                              select new OrderDto
                              {
                                  OrderItemId = orderItem.Id,
                                  Id = order.Id,
                                  OrderDate = order.OrderDate,
                                  Time = order.Time,
                                  total = order.total,
                                  status = order.status,
                                  Price = orderItem.Price,
                                  Quantity = orderItem.Quantity,
                                  Product = product
                              }).ToListAsync();
            else if (status.ToLower() == "inthebag")
                return await (from orderItem in Context.OrderItem
                              join order in Context.Order on orderItem.OrderId equals order.Id
                              join product in Context.Product on orderItem.ProductId equals product.Id
                              where order.Id == OrderId && order.status == Status.InTheBag
                              select new OrderDto
                              {
                                  OrderItemId = orderItem.Id,
                                  Id = order.Id,
                                  OrderDate = order.OrderDate,
                                  Time = order.Time,
                                  total = order.total,
                                  status = order.status,
                                  Price = orderItem.Price,
                                  Quantity = orderItem.Quantity,
                                  Product = product
                              }).ToListAsync();
            else
                return null;
        }

        public async Task<List<OrderDto>> GetOrderItemByCastomer(Guid CastomerId)
        {
            var a = await (from orderItem in Context.OrderItem
                           join order in Context.Order on orderItem.OrderId equals order.Id
                           join product in Context.Product on orderItem.ProductId equals product.Id
                           where CastomerId == order.CastomerId
                           select new OrderDto
                           {
                               OrderItemId = orderItem.Id,
                               Id = order.Id,
                               OrderDate = order.OrderDate,
                               Time = order.Time,
                               total = order.total,
                               status = order.status,
                               Price = orderItem.Price,
                               Quantity = orderItem.Quantity,
                               Product = product
                           }).ToListAsync();
            return a;
        }
        public async Task<List<OrderDto>> GetOrderItemByCompany(Guid CompanyId)
        {
            return await (from orderItem in Context.OrderItem
                          join order in Context.Order on orderItem.OrderId equals order.Id
                          join product in Context.Product on orderItem.ProductId equals product.Id
                          join productCompany in Context.ProductCompany on product.Id equals productCompany.ProductId
                          where CompanyId == productCompany.CompanyId
                          select new OrderDto
                          {
                              OrderItemId = orderItem.Id,
                              Id = order.Id,
                              OrderDate = order.OrderDate,
                              Time = order.Time,
                              total = order.total,
                              status = order.status,
                              Price = orderItem.Price,
                              Quantity = orderItem.Quantity,
                              Product = product
                          }).ToListAsync();
        }
        public void CreateOrderItem(OrderItem entity)
        {
            Add(entity);
        }
        public void UpdateOrderItem(OrderItem entity)
        {
            Update(entity);
        }
        public void DeleteOrderItem(OrderItem entity)
        {
            Delete(entity);
        }

        public async Task<List<OrderDto>> GetOrderItemByOrder(Guid OrderId)
        {
            return await(from orderItem in Context.OrderItem
                         join order in Context.Order on orderItem.OrderId equals order.Id
                         join product in Context.Product on orderItem.ProductId equals product.Id
                         join productCompany in Context.ProductCompany on product.Id equals productCompany.ProductId
                         where OrderId == order.Id
                         select new OrderDto
                         {
                             OrderItemId = orderItem.Id,
                             Id = order.Id,
                             OrderDate = order.OrderDate,
                             Time = order.Time,
                             total = order.total,
                             status = order.status,
                             Price = orderItem.Price,
                             Quantity = orderItem.Quantity,
                             Product = product
                         }).ToListAsync();
        }
    }
}