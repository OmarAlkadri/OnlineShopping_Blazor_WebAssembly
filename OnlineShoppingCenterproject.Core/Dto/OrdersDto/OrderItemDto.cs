using OnlineShoppingCenterproject.Core.Dto.CastomersDto;
using OnlineShoppingCenterproject.Core.Dto.CompanysDto;
using OnlineShoppingCenterproject.Core.Dto.ProductCompanysDto;

namespace OnlineShoppingCenterproject.Core.Dto.OrdersDto
{
    public class OrderItemDto
    {
        public Guid Id { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public Guid ProductId { get; set; }
        public Guid OrderId { get; set; }
    }
}