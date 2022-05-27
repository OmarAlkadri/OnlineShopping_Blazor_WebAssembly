using OnlineShoppingCenterproject.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoppingCenterproject.Core.Entities
{
    public class Address : IBaseEntity
    {
        public Guid Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        [RegularExpression(@"^[1-9]{1}[0-9]{9}$", ErrorMessage = "Not a valid phone number")]
        public string Phone { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string District { get; set; }
        [Required]
        public string Neighborhood { get; set; }
    }
}