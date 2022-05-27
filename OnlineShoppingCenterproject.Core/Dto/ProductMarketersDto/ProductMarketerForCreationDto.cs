using OnlineShoppingCenterproject.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoppingCenterproject.Core.Dto.ProductCompanysDto
{
    public class ProductCompanyForCreationDto
    {
        public ProductCompanyForCreationDto(ProductForCreationDto product)
        {
            Product = product;
        }
        public string type { get; set; }
        public ProductForCreationDto Product { get; set; }
        public Guid CompanyId { get; set; }
        public Boolean activations { get; set; }
    }
}
