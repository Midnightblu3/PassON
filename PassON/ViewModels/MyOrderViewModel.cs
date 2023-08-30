using PassON.Models;

namespace PassON.ViewModels
{
    public class MyOrderViewModel
    {
        public IEnumerable<Order> myOrders { get; set; } = default!;

    }
}
