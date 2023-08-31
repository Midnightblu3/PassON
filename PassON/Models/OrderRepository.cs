namespace PassON.Models
{
    public class OrderRepository: IOrderRespository
    {
        private readonly PassONDbContext _context;
        public OrderRepository (PassONDbContext context, IShoppingCart shoppingCart)
        {
            _context = context;
        }


        public void CreateOrder(Order order)
        {
           

            _context.Orders.Add(order);
            _context.SaveChanges();


        }

        public IEnumerable<Order> GetAllOrders()
        {
           return _context.Orders;
        }
    }
}
