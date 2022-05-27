using OnlineShoppingCenterproject.Core.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShoppingCenterproject.Core.Entities
{
    public class CastomerAddress : IBaseEntity
    {
        public Guid Id { get; set; }
        [Required]
        public string Title { get; set; }
        public Guid CastomerId { get; set; }
        public Castomer Castomer { get; set; }
        public Guid AddressId { get; set; }
        public Address Address { get; set; }
    }
}
