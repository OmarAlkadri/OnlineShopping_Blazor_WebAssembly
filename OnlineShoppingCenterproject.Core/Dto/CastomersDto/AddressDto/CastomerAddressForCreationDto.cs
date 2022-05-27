using OnlineShoppingCenterproject.Core.Dto.AddresssDto;
using OnlineShoppingCenterproject.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoppingCenterproject.Core.Dto.CastomersDto
{
    public class CastomerAddressForCreationDto
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public AddressForCreationDto Address { get; set; }
    }
}
