using OnlineShoppingCenterproject.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoppingCenterproject.Core.Entities
{
    public class OrderItem : IBaseEntity
    {
        public Guid Id { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
        public Guid OrderId { get; set; }
        public Order Order { get; set; }
    }
}