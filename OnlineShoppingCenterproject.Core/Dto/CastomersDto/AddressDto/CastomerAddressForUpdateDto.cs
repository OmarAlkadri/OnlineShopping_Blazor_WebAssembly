using OnlineShoppingCenterproject.Core.Dto.AddresssDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoppingCenterproject.Core.Dto.CastomersDto
{
    public class CastomerAddressForUpdateDto
    {
        public Guid Id { get; set; }
        public AddressForUpdateDto Address { get; set; }
    }
}
