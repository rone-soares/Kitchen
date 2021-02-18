using DataTransfer.Requests.Orders;
using DataTransfer.Responses.Orders;
using System.Collections.Generic;

namespace Business.Interfaces.Orders
{
    public interface IOrderItemAppService : ICrudAppService<OrderItemRequest, OrderItemResponse>
    {
        List<OrderItemResponse> SelectByOrder(int idOrder);
    }
}
