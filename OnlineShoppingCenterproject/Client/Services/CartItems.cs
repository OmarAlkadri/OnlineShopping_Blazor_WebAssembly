using OnlineShoppingCenterproject.Core.Entities;

namespace OnlineShoppingCenterproject.Client.Services
{
    public class CartItems
    {
        public CartItems()
        {
            Quantity = 0;
            Price = 0;
        }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
    }
}
