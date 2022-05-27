using OnlineShoppingCenterproject.Core.Entities.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoppingCenterproject.Core.Dto.ProductCompanysDto
{
    public class ProductForCreationDto
    {
        public ProductForCreationDto()
        {
            IsClick = false;
        }

        [Required]
        [StringLength(25, ErrorMessage = "Name is too long.")]
        [Display(Name = "Product Name")]
        public string Name { get; set; }
        [Required]
        public string CompanyName { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public string ModelNumber { get; set; }
        [Required]
        [Range(1, 2000000000, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int Quantity { get; set; }
        [Required]
        public string WarrantyCompany { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        [Display(Name = "foto")]
        public string Foto { get; set; }
        [Required]
        [Range(1, 100000, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public double UnitPrice { get; set; }
        public Boolean IsClick { get; set; }

    }
}
