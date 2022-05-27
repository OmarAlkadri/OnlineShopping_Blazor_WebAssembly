using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoppingCenterproject.Core.Dto.ProductCompanysDto
{
    public class ProductDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Title { get; set; }
        public string CompanyName { get; set; }
        public string ModelNumber { get; set; }
        public string WarrantyCompany { get; set; }
        public int Quantity { get; set; }
        public string Foto { get; set; }
        public double UnitPrice { get; set; }
        public Boolean IsClick { get; set; } = false;
    }
}
