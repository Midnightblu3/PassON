namespace PassON.Models
{
    public interface IShoppingCart
    {
        void AddToCart(Item item);
        int RemoveFromCart(Item item);

        List<ShoppingCartItem> GetAllShoppingCartItems();

        void ClearCart();

        decimal GetTotalPrice();

        List<ShoppingCartItem> ShoppingCartItems { get; set; }

    }
}
