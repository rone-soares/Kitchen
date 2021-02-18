using Business.Interfaces.Registrations;
using DataTransfer.Requests.Registrations;
using Domain.Entities.Orders;
using Domain.Entities.Registrations;
using Domain.Repositories.Orders;
using System.Collections.Generic;
using System.Linq;

namespace Business.Services.Registrations
{
    public class PointOfSaleMapService : IPointOfSaleMapService
    {
        private readonly IOrderRepository orderRepository;
        private readonly IOrderItemRepository orderItemRepository;

        public PointOfSaleMapService(IOrderRepository orderRepository, IOrderItemRepository orderItemRepository)
        {
            this.orderRepository = orderRepository;
            this.orderItemRepository = orderItemRepository;
        }

        public PointOfSale MapEntity(PointOfSaleRequest request)
        {
            PointOfSale pointOfSale = new PointOfSale(request.Id, request.Number, request.TypePointOfSale);

            UpdateOrder(pointOfSale);

            UpdateOrderItem(pointOfSale);

            return pointOfSale;
        }

        private void UpdateOrder(PointOfSale entity)
        {
            List<Order> list = orderRepository.GetInstance().Select().Where(x => x.PointOfSale.Id == entity.Id)
                .Select(s => new Order(s.Id, s.Waiter, s.PointOfSale, s.Table, s.CreationDate, s.StatusOrder)).ToList();

            foreach (var obj in list)
            {
                obj.SetPointOfSale(entity);

                orderRepository.GetInstance().Update(obj);
            }
        }

        private void UpdateOrderItem(PointOfSale entity)
        {
            List<OrderItem> list = orderItemRepository.GetInstance().Select().Where(x => x.Order.PointOfSale.Id == entity.Id)
                .Select(s => new OrderItem(s.Id, s.Order, s.Product, s.Amount)).ToList();

            foreach (var obj in list)
            {
                obj.Order.SetPointOfSale(entity);

                orderItemRepository.GetInstance().Update(obj);
            }
        }
    }
}
