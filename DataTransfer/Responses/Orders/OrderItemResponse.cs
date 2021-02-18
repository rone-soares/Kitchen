using DataTransfer.Responses.Registrations;

namespace DataTransfer.Responses.Orders
{
    public class OrderItemResponse
    {
        public int Id { get; set; }
        public OrderResponse Order { get; set; }
        public ProductResponse Product { get; set; }
        public int Amount { get; set; }
    }
}
