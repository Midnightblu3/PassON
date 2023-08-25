using PassON.Models;

namespace PassON.ViewModels
{
    public class ShoppingCartViewModel
    {

        public IShoppingCart ShoppingCart { get; set; }
        public decimal ShoppingCartTotal { get; set; }

        /// <summary>
        /// Constructor for shopping cart view model
        /// </summary>
        /// <param name="shoppingCart">Shopping cart field </param>
        /// <param name="shoppingCartTatal">shopping cart total </param>
        public ShoppingCartViewModel(IShoppingCart shoppingCart, decimal shoppingCartTotal)
        {
            ShoppingCart = shoppingCart;
            ShoppingCartTotal = shoppingCartTotal;
        }

    }
}
