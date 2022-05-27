using OnlineShoppingCenterproject.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoppingCenterproject.Core.Dto.AddresssDto
{
    public class AddressDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Phone { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Neighborhood { get; set; }
    }
}
