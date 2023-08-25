using PassON.Models;
using Microsoft.AspNetCore.Mvc;
using PassON.ViewModels;

namespace PassON.Controllers
{
    public class ShoppingCartController: Controller
    {
        private readonly IItemRepository _itemRepository;
        private readonly IShoppingCart _shoppingCart;

        public ShoppingCartController(IItemRepository itemRepository, IShoppingCart shoppingCart)
        {
            _itemRepository = itemRepository;
            _shoppingCart = shoppingCart;

        }

        /// <summary>
        /// Go to ShoppingCart Index with shopping cart view model
        /// </summary>
        /// <returns>return the ShoppingCart Index view</returns>
        public ViewResult Index()
        {
            var items = _shoppingCart.GetAllShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;
            var total = _shoppingCart.GetTotalPrice();
            ShoppingCartViewModel shoppingCartViewModel = new ShoppingCartViewModel(_shoppingCart, total);

            return View(shoppingCartViewModel);
        }

        /// <summary>
        /// Add an Item to Shopping Cart
        /// </summary>
        /// <param name="itemId">Item Id of the Item</param>
        /// <returns>to ShoppingCart/Index</returns>
        public RedirectToActionResult AddToShoppingCart(int itemId)
        {
            var selectedItem = _itemRepository.Get(itemId);
            if (selectedItem != null)
            {
                _shoppingCart.AddToCart(selectedItem);
            }
            return RedirectToAction("Index");
        }

        /// <summary>
        /// Remove an Item from Shopping Cart
        /// </summary>
        /// <param name="itemId">Id of the Item</param>
        /// <returns>ShoppingCart/Index</returns>

        public RedirectToActionResult RemoveFromShoppingCart(int itemId)
        {
            var selectedItem = _itemRepository.Get(itemId);
            if (selectedItem != null)
            {
                _shoppingCart.RemoveFromCart(selectedItem);
            }
            return RedirectToAction("Index");

        }

    }
}
