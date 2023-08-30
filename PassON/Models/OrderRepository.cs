namespace PassON.Models
{
    public class OrderRepository: IOrderRespository
    {
        private readonly PassONDbContext _context;
        private readonly IShoppingCart _shoppingCart;

        public OrderRepository (PassONDbContext context, IShoppingCart shoppingCart)
        {
            _context = context;
            _shoppingCart = shoppingCart;
        }


        public void CreateOrder(Order order)
        {
           order.OrderPlace = DateTime.Now;

            List<ShoppingCartItem> shoppingCartItems = _shoppingCart.ShoppingCartItems;
            order.OrderDetails = new List<OrderDetail>();
            foreach(ShoppingCartItem s in shoppingCartItems)
            {
                order.OrderDetails.Add(new OrderDetail
                {
                    ItemId = s.Item.Id,
                    Amount = s.Amount,
                    Price = s.Item.Price
                });

            }

            _context.Orders.Add(order);
            _context.SaveChanges();


        }

        public IEnumerable<Order> GetAllOrders()
        {
           return _context.Orders;
        }
    }
}
