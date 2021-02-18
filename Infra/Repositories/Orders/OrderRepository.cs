using Domain.Entities.Orders;
using Domain.Repositories.Orders;
using Domain.Repositories;

namespace Repository.Repositories.Orders
{
    public class OrderRepository : RepositoryOnMemory<Order>, IOrderRepository
    {
        public OrderRepository() : base()
        {
        }
    }
}
