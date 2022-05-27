using OnlineShoppingCenterproject.Core.Dto.CastomersDto;
using OnlineShoppingCenterproject.Core.Dto.ProductCompanysDto;
using OnlineShoppingCenterproject.Core.Entities;

namespace OnlineShoppingCenterproject.Core.Dto.OrdersDto
{
    public class OrderDto
    {
        public Guid Id { get; set; }
        public Guid OrderItemId { get; set; }
        public DateTime OrderDate { get; set; }
        public string Time { get; set; }
        public double total { get; set; }
        public Status status { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public Product Product { get; set; }
        public Castomer Castomer { get; set; }
    }
}