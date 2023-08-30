namespace PassON.Models
{
    public interface IOrderRespository
    {
        public void CreateOrder(Order order);
        public IEnumerable<Order> GetAllOrders();
    }
}
