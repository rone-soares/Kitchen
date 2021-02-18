using DataTransfer.Requests.Orders;
using DataTransfer.Responses.Orders;

namespace Business.Interfaces.Orders
{
    public interface IOrderAppService : ICrudAppService<OrderRequest, OrderResponse>
    {
        int CreateAnOrderWithItems(OrderWithItemsRequest orderWithItems);        
        void InProgressOrder(int id);
        void FinishedOrder(int id);
        void CancelOrder(int id);
    }
}
