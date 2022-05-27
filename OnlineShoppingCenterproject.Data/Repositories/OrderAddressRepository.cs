using Microsoft.EntityFrameworkCore;
using OnlineShoppingCenterproject.Core.Entities;
using OnlineShoppingCenterproject.Core.Interfaces;
using OnlineShoppingCenterproject.Data_DB;

namespace OnlineShoppingCenterproject.Data.Repositories
{
    public class OrderAddressRepository : RepositoryBase<OrderAddress>, IOrderAddressRepository
    {
        public OrderAddressRepository(Context_DB Context) : base(Context)
        {

        }
        public async Task<IEnumerable<OrderAddress>> GetAllOrderAddress()
        {
            var b = await (from orderAddress in Context.OrderAddress
                           select new OrderAddress
                           {
                               Id = orderAddress.Id,
                               OrderId = orderAddress.OrderId,
                               AddressId = orderAddress.AddressId,
                           }).ToListAsync();
            return b;
        }
        public async Task<OrderAddress> GetOrderAddressId(Guid Id)
        {
            var b = await (from orderAddress in Context.OrderAddress
                           where orderAddress.Id == Id
                           select new OrderAddress
                           {
                               Id = orderAddress.Id,
                               OrderId = orderAddress.OrderId,
                               AddressId = orderAddress.AddressId,
                           }).FirstAsync();
            return b;
        }
        public void CreateOrderAddress(OrderAddress entity)
        {
            Add(entity);
        }
        public void UpdateOrderAddress(OrderAddress entity)
        {
            Update(entity);
        }
    }
}