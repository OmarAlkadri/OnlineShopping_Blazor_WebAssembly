using OnlineShoppingCenterproject.Core.Entities;

namespace OnlineShoppingCenterproject.Core.Dto.ProductCompanysDto
{
    public class ProductCompanyDto
    {
        public Guid Id { get; set; }
        public string type { get; set; }
        public Product Product { get; set; }
        public Guid CompanyId { get; set; }
    }
}
