using OnlineShoppingCenterproject.Core.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShoppingCenterproject.Core.Entities
{
    public class ProductCompany : IBaseEntity
    {
        public Guid Id { get; set; }
        [Required]
        public string type { get; set; }

        [ForeignKey(nameof(Product))]
        public Guid ProductId { get; set; }
        public Product Product { get; set; }

        [ForeignKey(nameof(Company))]
        public Guid CompanyId { get; set; }
        public Company Company { get; set; }
    }
}