namespace PassON.Models
{
    public class OrderDetailRespository : IOrderDetailRespository
    {
        private readonly PassONDbContext _context;


        public OrderDetailRespository(PassONDbContext context)
        {
            _context = context;
        }

        public IEnumerable<OrderDetail> GetAllOrderDetails()
        {
            return _context.OrderDetails;
        }

        public IEnumerable<OrderDetail> GetOrderDetailsForOrder(int orderId)
        {
            return _context.OrderDetails.Where(od=>od.OrderId==orderId);
        }
    }
}
