using OnlineShoppingCenterproject.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoppingCenterproject.Core.Dto.OrdersDto
{
    public class OrderAddressDto
    {
        public Guid Id { get; set; }
        public Guid OrderId { get; set; }
        public Guid AddressId { get; set; }
    }
}
