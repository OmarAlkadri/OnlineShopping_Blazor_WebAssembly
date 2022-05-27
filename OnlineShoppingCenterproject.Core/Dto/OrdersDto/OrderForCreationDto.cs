using OnlineShoppingCenterproject.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoppingCenterproject.Core.Dto.OrdersDto
{
    public class OrderForCreationDto
    {
        public OrderForCreationDto()
        {
            total = 0;
            status = Status.InTheBag;
        }
        public DateTime? OrderDate { get; set; }
        public string Time { get; set; }
        public double? total { get; set; }
        public Status status { get; set; }
        public int CastomerId { get; set; }
    }
}
