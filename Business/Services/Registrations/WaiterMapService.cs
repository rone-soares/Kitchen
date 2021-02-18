using Business.Interfaces.Registrations;
using DataTransfer.Requests.Registrations;
using Domain.Entities.Orders;
using Domain.Entities.Registrations;
using Domain.Repositories.Orders;
using System.Collections.Generic;
using System.Linq;

namespace Business.Services.Registrations
{
    public class WaiterMapService : IWaiterMapService
    {
        private readonly IOrderRepository orderRepository;
        private readonly IOrderItemRepository orderItemRepository;

        public WaiterMapService(IOrderRepository orderRepository, IOrderItemRepository orderItemRepository)
        {
            this.orderRepository = orderRepository;
            this.orderItemRepository = orderItemRepository;
        }

        public Waiter MapEntity(WaiterRequest request)
        {
            Waiter waiter = new Waiter(request.Id, request.Name);

            UpdateOrder(waiter);

            UpdateOrderItem(waiter);

            return waiter;
        }

        private void UpdateOrder(Waiter entity)
        {
            List<Order> list = orderRepository.GetInstance().Select().Where(x => x.Waiter.Id == entity.Id)
                .Select(s => new Order(s.Id, s.Waiter, s.PointOfSale, s.Table, s.CreationDate, s.StatusOrder)).ToList();

            foreach (var obj in list)
            {
                obj.SetWaiter(entity);

                orderRepository.GetInstance().Update(obj);
            }
        }

        private void UpdateOrderItem(Waiter entity)
        {
            List<OrderItem> list = orderItemRepository.GetInstance().Select().Where(x => x.Order.Waiter.Id == entity.Id)
                .Select(s => new OrderItem(s.Id, s.Order, s.Product, s.Amount)).ToList();

            foreach (var obj in list)
            {
                obj.Order.SetWaiter(entity);

                orderItemRepository.GetInstance().Update(obj);
            }
        }
    }
}
