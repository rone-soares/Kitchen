using Business.Interfaces.Orders;
using DataTransfer.Requests.Orders;
using DataTransfer.Responses.Orders;
using Domain.Entities.Orders;
using Domain.Repositories.Orders;
using Library.Resources;
using Library.Service;
using System.Collections.Generic;

namespace Business.AppServices.Orders
{
    public class OrderItemAppService : CrudAppService<OrderItem, OrderItemRequest, OrderItemResponse, IOrderItemRepository, IOrderItemMapService>, IOrderItemAppService
    {
        public OrderItemAppService(IOrderItemRepository repository, IOrderItemMapService mapService) : base(repository, mapService, FieldResource.OrderItem)
        {
        }

        public List<OrderItemResponse> SelectByOrder(int idOrder)
        {
            ValidationService.ValidateParameterId(idOrder, FieldResource.Order);

            return MapEntityListToResponseList(repository.SelectByOrder(idOrder));
        }
    }
}
