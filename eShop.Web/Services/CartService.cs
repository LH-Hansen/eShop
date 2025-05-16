using Blazored.LocalStorage;
using eShop.Repository.Entities;

namespace eShop.Web.Services
{
    public class CartService
    {
        private const string CartKey = "cart_items";
        private readonly ILocalStorageService _localStorage;

        private List<Product> _cartItems = new();

        public IReadOnlyList<Product> CartItems => _cartItems;

        public CartService(ILocalStorageService localStorage)
        {
            _localStorage = localStorage;
        }

        public async Task InitializeAsync()
        {
            _cartItems = await _localStorage.GetItemAsync<List<Product>>(CartKey) ?? new List<Product>();
        }

        public async Task AddToCart(Product product)
        {
            if (!_cartItems.Exists(p => p.Id == product.Id))
            {
                _cartItems.Add(product);
                await SaveCart();
            }
        }

        public async Task RemoveFromCart(int productId)
        {
            Product item = _cartItems.Find(p => p.Id == productId);
            if (item != null)
            {
                _cartItems.Remove(item);
                await SaveCart();
            }
        }

        public async Task ClearCart()
        {
            _cartItems.Clear();
            await SaveCart();
        }

        private async Task SaveCart()
        {
            await _localStorage.SetItemAsync(CartKey, _cartItems);
        }
    }
}
