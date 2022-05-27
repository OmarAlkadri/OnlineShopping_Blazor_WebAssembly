using AutoMapper;
using Blazored.LocalStorage;
using Blazored.Toast.Services;
using OnlineShoppingCenterproject.Core.Dto.ProductCompanysDto;
using OnlineShoppingCenterproject.Core.Entities;

namespace OnlineShoppingCenterproject.Client.Services
{
    public interface ICartService
    {
        event Action OnChange;
        Task AddToCart(CartItems item);
        Task<List<CartItems>> GetCartItems();
        Task DeleteItem(CartItems item);
        Task UpdateItem(CartItems item);
        Task EmptyCart();
    }
    public class CartService : ICartService
    {
        private readonly ILocalStorageService _localStorage;
        private readonly IToastService _toastService;

        public event Action OnChange;
        public CartService(
            ILocalStorageService localStorage,
            IToastService toastService)
        {
            _localStorage = localStorage;
            _toastService = toastService;
        }

        public async Task AddToCart(CartItems item)
        {
            var cart = await _localStorage.GetItemAsync<List<CartItems>>("cart");
            if (cart == null)
            {
                cart = new List<CartItems>();
            }

            var sameItem = cart.Find(x => x.ProductId == item.ProductId);
            if (sameItem == null)
            {
                cart.Add(item);
            }
            else
            {
                if (item.Quantity == 1)
                    sameItem.Quantity += item.Quantity;
                else
                    sameItem.Quantity = item.Quantity;
            }

            await _localStorage.SetItemAsync("cart", cart);

            // var product = await _productService.GetProduct(item.ProductId);
            _toastService.ShowSuccess(item.ProductId.ToString(), "Added to cart:");
            OnChange.Invoke();
        }

        public async Task<List<CartItems>> GetCartItems()
        {
            var cart = await _localStorage.GetItemAsync<List<CartItems>>("cart");
            if (cart == null)
            {
                return new List<CartItems>();
            }
            return cart;
        }

        public async Task DeleteItem(CartItems item)
        {
            var cart = await _localStorage.GetItemAsync<List<CartItems>>("cart");
            if (cart == null)
            {
                return;
            }

            var cartItem = cart.Find(x => x.ProductId == item.ProductId);
            cart.Remove(cartItem);

            await _localStorage.SetItemAsync("cart", cart);
            OnChange.Invoke();
        }
        public async Task UpdateItem(CartItems item)
        {
            var cart = await _localStorage.GetItemAsync<List<CartItems>>("cart");
            if (cart == null)
                return;
            var cartItem = cart.Find(x => x.ProductId == item.ProductId);
            cartItem.Quantity = item.Quantity;
            await _localStorage.SetItemAsync("cart", cart);
            OnChange.Invoke();
        }
        public async Task EmptyCart()
        {
            var cart = await _localStorage.GetItemAsync<List<CartItems>>("cart");
            if (cart == null)
                return;

            cart.Clear();
            await _localStorage.SetItemAsync("cart", cart);
            OnChange.Invoke();
        }
    }
}
