using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PassON.Models;

namespace PassON.Controllers
{
    [Authorize]
    public class OrderController: Controller
    {
        private readonly IOrderRespository _orderRespository;
        private readonly IShoppingCart _shoppingCart;

        public OrderController(IOrderRespository orderRespository, IShoppingCart shoppingCart)
        {
            _orderRespository = orderRespository;
            _shoppingCart = shoppingCart;
        }

        public IActionResult Checkout()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            var items = _shoppingCart.GetAllShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;
            if(_shoppingCart.ShoppingCartItems.Count == 0)
            {
                ModelState.AddModelError("", " Your cart is empty, add some products first");
            }

            if (ModelState.IsValid)
            {
                _orderRespository.CreateOrder(order);
                _shoppingCart.ClearCart();
                return RedirectToAction("CheckoutComplete");
            }

            return View(order);
        }

        public IActionResult CheckoutComplete()
        {
            ViewBag.CheckoutCompleteMessage = "Thank you for your order!";
            return View();
        }

    }
}
