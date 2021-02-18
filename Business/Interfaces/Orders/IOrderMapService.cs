using DataTransfer.Requests.Orders;
using Domain.Entities.Orders;

namespace Business.Interfaces.Orders
{
    public interface IOrderMapService : IMapService<Order, OrderRequest>
    {
    }
}
