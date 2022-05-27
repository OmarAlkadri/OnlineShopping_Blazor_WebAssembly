using OnlineShoppingCenterproject.Core.Dto.AddresssDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoppingCenterproject.Core.Dto.OrdersDto
{
    public class OrderAddressForUpdateDto
    {
        public Guid Id { get; set; }
        public AddressForUpdateDto Address { get; set; }
    }
}
