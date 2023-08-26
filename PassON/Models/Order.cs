

namespace PassON.Models
{
    public class Order
    {
        public int Id { get; set; }
        public List<OrderDetail>? OrderDetails { get; set; }

        public string FirstName { get; set; } =string.Empty;

        public string LastName { get; set; } =string.Empty;

        public string AddressLine1 { get; set; } =string.Empty;

        public string AddressLine2 { get; set; } =string.Empty;

        public string ZipCode { get; set; } =string.Empty;
        
        public string City { get; set; } =string.Empty;

        public string? State { get; set; }

        public string Country { get; set; } =string.Empty;

        public string PhoneNumber { get; set; } =string.Empty;

        public string Email { set; get; } =string.Empty;

        public decimal OrderTotal { get; set; } =decimal.Zero;

        public DateTime OrderPlace { get; set; }


    }
}
