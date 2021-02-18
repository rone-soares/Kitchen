using System.Collections.Generic;

namespace DataTransfer.Requests.Orders
{
    public class OrderWithItemsRequest
    {
        public OrderRequest Order { get; set; }
        public List<OrderItemRequest> OrderItem { get; set; }
    }
}
