using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoppingCenterproject.Core.Dto.OrdersDto
{
    public class OrderItemsList
    {
        public OrderItemsList()
        {
            IsClick = false;
        }
        public Boolean IsClick { get; set; }
        public string UserName { get; set; }
        public Guid AddressId { get; set; }
        public List<OrderItemForCreationDto> OrderItem { get; set; }
    }
}
