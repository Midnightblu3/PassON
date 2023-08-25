using Microsoft.EntityFrameworkCore;

namespace PassON.Models
{
    public class ShoppingCart : IShoppingCart
    {

        private readonly PassONDbContext _DbContext;

        public ShoppingCart(PassONDbContext DbContext)
        {
            _DbContext = DbContext;
        }

        public string? ShoppingCartId { get; set; }
        public List<ShoppingCartItem> ShoppingCartItems { get; set; } = default!;


        /**
         * initialize the cart with Session variable
         */

        public static ShoppingCart GetCart(IServiceProvider services)
        {
            ISession? session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext?.Session;
            PassONDbContext dbContext = services.GetService<PassONDbContext>() ?? throw new Exception("Error initialization");

            string CartId= session?.GetString("CartId")?? Guid.NewGuid().ToString();

            session?.SetString("CartId", CartId);

            return new ShoppingCart(dbContext) { ShoppingCartId = CartId };


        }

        /**
         * Add item to cart
         */

        public void AddToCart(Item item)
        {
            var shoppingCartItem = _DbContext.ShoppingCartItems.SingleOrDefault(s => s.Item.Id == item.Id && s.ShoppingCardId == ShoppingCartId);
            if(shoppingCartItem == null) {

                shoppingCartItem = new ShoppingCartItem
                {
                    ShoppingCardId = ShoppingCartId,
                    Item = item,
                    Amount = 1
                };

                _DbContext.ShoppingCartItems.Add(shoppingCartItem);
            }
            else
            {
                shoppingCartItem.Amount++;
            }
            _DbContext.SaveChanges();
        }

        /**
         * Remove all shopping cart item in the cart
         */

        public void ClearCart()
        {
            var removeItems = _DbContext.ShoppingCartItems.Where(s => s.ShoppingCardId == ShoppingCartId);
            _DbContext.RemoveRange(removeItems);
            ShoppingCartItems.Clear();
            _DbContext.SaveChanges();
        }

        /**
         * get all shopcartItems for this shopping cart
         */
        public List<ShoppingCartItem> GetAllShoppingCartItems()
        {
            return ShoppingCartItems??=_DbContext.ShoppingCartItems.Where(s => s.ShoppingCardId == ShoppingCartId).Include(s=>s.Item).ToList();
        }


        /**
         * Calculate tatal for the shopping cart
         */
        public decimal GetTotalPrice()
        {
            var totalPrice = _DbContext.ShoppingCartItems.Where(s=>s.ShoppingCardId==ShoppingCartId).Select(c=>c.Item.Price* c.Amount).Sum();

            return (decimal)totalPrice;

        }

        /**
         * remove Item from the shopping cart
         */
        public int RemoveFromCart(Item item)
        {
            var shoppingCartItem = _DbContext.ShoppingCartItems.SingleOrDefault(s => s.Item.Id == item.Id && s.ShoppingCardId == ShoppingCartId);

            var localAmount = 0;
            if (shoppingCartItem != null)
            {
                if(shoppingCartItem.Amount > 1)
                {
                    shoppingCartItem.Amount--;
                    localAmount=shoppingCartItem.Amount;
                }
                else
                {
                    _DbContext.ShoppingCartItems.Remove(shoppingCartItem);
                }
            }
            _DbContext.SaveChanges();
            return localAmount;
        }
    }
}
