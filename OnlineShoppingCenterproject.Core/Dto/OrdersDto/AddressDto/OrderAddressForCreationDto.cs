using OnlineShoppingCenterproject.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoppingCenterproject.Core.Dto.OrdersDto
{
    public class OrderAddressForCreationDto
    {
        public int AddressId { get; set; }
        public OrderForCreationDto? Order { get; set; }
    }
}
