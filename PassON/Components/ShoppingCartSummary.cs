using Microsoft.AspNetCore.Mvc;
using PassON.Models;
using PassON.ViewModels;

namespace PassON.Components
{
    public class ShoppingCartSummary: ViewComponent
    {
        private readonly IShoppingCart _shoppingCart;

        public ShoppingCartSummary(IShoppingCart shoppingCart)
        {
            _shoppingCart = shoppingCart;
        }

        public IViewComponentResult Invoke()
        {
            var items = _shoppingCart.GetAllShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;

            var shoppingCartViewModel = new ShoppingCartViewModel(_shoppingCart, _shoppingCart.GetTotalPrice());

            return View(shoppingCartViewModel);
        }
    }
}
