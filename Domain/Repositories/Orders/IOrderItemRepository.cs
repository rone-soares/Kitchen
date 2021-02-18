using Domain.Entities.Orders;
using System.Collections.Generic;

namespace Domain.Repositories.Orders
{
    public interface IOrderItemRepository : IRepository<OrderItem>
    {
        List<OrderItem> SelectByOrder(int idOrder);
    }
}
