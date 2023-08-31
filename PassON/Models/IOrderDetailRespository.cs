namespace PassON.Models
{
    public interface IOrderDetailRespository
    {
        IEnumerable<OrderDetail> GetAllOrderDetails ();
        IEnumerable<OrderDetail> GetOrderDetailsForOrder(int orderId);
    }
}
