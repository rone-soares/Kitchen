namespace DataTransfer.Requests.Orders
{
    public class OrderItemRequest : RequestBase
    {
        public int IdOrder { get; set; }
        public int IdProduct { get; set; }
        public int Amount { get; set; }
    }
}
