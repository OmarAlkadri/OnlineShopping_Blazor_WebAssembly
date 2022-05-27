using OnlineShoppingCenterproject.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoppingCenterproject.Core.Dto.AddresssDto
{
    public class AddressForCreationDto
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string District { get; set; }
        [Required]
        public string Neighborhood { get; set; }
    }
}
