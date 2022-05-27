using System.ComponentModel.DataAnnotations;

namespace OnlineShoppingCenterproject.Core.Dto.ProductCompanysDto
{
    public class ProductForUpdateDto
    {
        [StringLength(15, ErrorMessage = "Name is too long.")]
        [Display(Name = "Product Name")]
        public string? Name { get; set; }
        public string? CompanyName { get; set; }
        public string? Type { get; set; }
        public string? ModelNumber { get; set; }
        public string? WarrantyCompany { get; set; }
        public int Quantity { get; set; } = 0;
        public string? Title { get; set; }
        public string? Foto { get; set; }
        public double UnitPrice { get; set; } = 0;
		public Boolean IsClick { get; set; } = false;
	}
}