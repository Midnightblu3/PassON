using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PassON.Models;

namespace PassON.Controllers
{
    [Authorize]
    public class OrderController: Controller
    {
        private readonly IOrderRespository _orderRespository;
        private readonly IShoppingCart _shoppingCart;
       
        public OrderController(IOrderRespository orderRespository, IShoppingCart shoppingCart , UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
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
                order.OrderPlace = DateTime.Now;

                List<ShoppingCartItem> shoppingCartItems = _shoppingCart.ShoppingCartItems;
                order.OrderDetails = new List<OrderDetail>();
                foreach (ShoppingCartItem s in shoppingCartItems)
                {
                    order.OrderDetails.Add(new OrderDetail
                    {
                        ItemId = s.Item.Id,
                        Amount = s.Amount,
                        Price = s.Item.Price,
                        OrderId=order.Id
                    });

                }
                order.OrderTotal=_shoppingCart.GetTotalPrice();

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
