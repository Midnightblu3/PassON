namespace PassON.Models
{
    public class ShoppingCartItem
    {
        public int ShoppingCartItemId { get; set; }
        public Item Item { get; set; } = default!;
        
        public int Amount { get; set; }

        public string? ShoppingCardId { get; set; }
    }
}
