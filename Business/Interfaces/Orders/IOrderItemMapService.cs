using DataTransfer.Requests.Orders;
using Domain.Entities.Orders;

namespace Business.Interfaces.Orders
{
    public interface IOrderItemMapService : IMapService<OrderItem, OrderItemRequest>
    {
    }
}
