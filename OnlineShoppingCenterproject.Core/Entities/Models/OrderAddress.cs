using OnlineShoppingCenterproject.Core.Interfaces;

namespace OnlineShoppingCenterproject.Core.Entities
{
    public class OrderAddress : IBaseEntity
    {
        public Guid Id { get; set; }
        public Guid OrderId { get; set; }
        public Order Order { get; set; }
        public Guid AddressId { get; set; }
        public Address Address { get; set; }
    }
}