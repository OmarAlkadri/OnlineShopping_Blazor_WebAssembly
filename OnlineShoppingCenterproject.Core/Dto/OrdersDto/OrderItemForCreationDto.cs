using OnlineShoppingCenterproject.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoppingCenterproject.Core.Dto.OrdersDto
{
    public class OrderItemForCreationDto
    {
        public int Quantity { get; set; }
        public double Price { get; set; }
        public Guid ProductId { get; set; }
        public Order? Order { get; set; }
    }
}
