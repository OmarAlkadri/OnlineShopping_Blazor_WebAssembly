using Microsoft.EntityFrameworkCore;
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
    public class Order_Repository : RepositoryBase<Order>, IOrderRepository
    {
        public Order_Repository(Context_DB Context) : base(Context)
        {

        }
        public async Task<IEnumerable<Order>> GetAllOrder(string userName)
        {
            var a = await (from data in Context.Order 
                           where data.Castomer.UserName == userName
                           select new Order
                           {
                               Id = data.Id,
                               OrderDate = data.OrderDate,
                               Time = data.Time,
                               total = data.total,
                               status = data.status,
                               Castomer = data.Castomer,
                           }).ToListAsync();
            return a;
        }

        public async Task<Order> GetOrderById(Guid Id)
        {
            return await Context.Order.FindAsync(Id);

        }
        public void CreateOrder(Order entity)
        {
            Add(entity);
        }
        public void UpdateOrder(Order entity)
        {
            Update(entity);
        }
        public void DeleteOrder(Order entity)
        {
            Delete(entity);
        }

        public async Task<Order> DeleteOrderById(Guid OrderId)
        {
            var a = await (from order in Context.Order
                           where order.Id == OrderId
                           select order).FirstAsync();
            if (a.status == Status.InTheBag)
            {
                return a;
            }
            else
            {
                return null;
            }
        }
    }
}
