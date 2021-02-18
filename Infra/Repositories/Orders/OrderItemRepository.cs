using Domain.Entities.Orders;
using Domain.Repositories;
using Domain.Repositories.Orders;
using System.Collections.Generic;
using System.Linq;

namespace Repository.Repositories.Orders
{
    public class OrderItemRepository : RepositoryOnMemory<OrderItem>, IOrderItemRepository
    {
        public OrderItemRepository() : base()
        {
        }

        public List<OrderItem> SelectByOrder(int idOrder)
        {
            return GetInstance().Select().Where(x => x.Order.Id == idOrder).ToList();
        }
    }
}
