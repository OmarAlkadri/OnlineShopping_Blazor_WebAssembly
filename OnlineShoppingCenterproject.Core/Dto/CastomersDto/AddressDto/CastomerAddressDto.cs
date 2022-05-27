using OnlineShoppingCenterproject.Core.Dto.AddresssDto;
using OnlineShoppingCenterproject.Core.Dto.UsersDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoppingCenterproject.Core.Dto.CastomersDto
{
    public class CastomerAddressDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public CastomerDto Castomer { get; set; }
        public AddressDto Address { get; set; }
    }
}
