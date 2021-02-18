using Business.Interfaces.Orders;
using DataTransfer.Requests.Orders;
using DataTransfer.Responses.Orders;
using Domain.Entities.Orders;
using Domain.Entities.Orders.Enums;
using Domain.Repositories.Orders;
using Library.Resources;
using Library.Service;
using System.Linq;

namespace Business.AppServices.Orders
{
    public class OrderAppService : CrudAppService<Order, OrderRequest, OrderResponse, IOrderRepository, IOrderMapService>, IOrderAppService
    {
        private readonly IOrderItemAppService orderItemAppService;

        public OrderAppService(IOrderRepository repository, IOrderMapService mapService, IOrderItemAppService orderItemAppService) : base(repository, mapService, FieldResource.Order)
        {
            this.orderItemAppService = orderItemAppService;
        }

        public int CreateAnOrderWithItems(OrderWithItemsRequest orderWithItems)
        {
            ValidationService.ValidateExistRequest(orderWithItems, field);

            Order order = mapService.MapEntity(orderWithItems.Order);

            var idOrder = repository.GetInstance().Insert(order);

            foreach(OrderItemRequest item in orderWithItems.OrderItem)
            {
                item.IdOrder = idOrder;

                orderItemAppService.Insert(item);
            }

            return idOrder;
        }

        public void InProgressOrder(int id)
        {
            UpdateStatusOrder(id, StatusOrderEnum.InProgress);
        }

        public void FinishedOrder(int id)
        {
            UpdateStatusOrder(id, StatusOrderEnum.Finished);
        }

        public void CancelOrder(int id)
        {
            UpdateStatusOrder(id, StatusOrderEnum.Cancelled);
        }

        private void UpdateStatusOrder(int id, StatusOrderEnum statusOrder)
        {
            ValidationService.ValidateParameterId(id, field);

            var order = repository.GetInstance().Select(id).FirstOrDefault();

            order.SetStatusOrder(statusOrder);

            repository.Update(order);
        }
    }
}
