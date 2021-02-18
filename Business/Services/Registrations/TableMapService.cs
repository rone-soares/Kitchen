using Business.Interfaces.Registrations;
using DataTransfer.Requests.Registrations;
using Domain.Entities.Orders;
using Domain.Entities.Registrations;
using Domain.Repositories.Orders;
using System.Collections.Generic;
using System.Linq;

namespace Business.Services.Registrations
{
    public class TableMapService : ITableMapService
    {
        private readonly IOrderRepository orderRepository;
        private readonly IOrderItemRepository orderItemRepository;

        public TableMapService(IOrderRepository orderRepository, IOrderItemRepository orderItemRepository)
        {
            this.orderRepository = orderRepository;
            this.orderItemRepository = orderItemRepository;
        }

        public Table MapEntity(TableRequest request)
        {
            Table table = new Table(request.Id, request.Number);

            UpdateOrder(table);

            UpdateOrderItem(table);

            return table;
        }

        private void UpdateOrder(Table entity)
        {
            List<Order> list = orderRepository.GetInstance().Select().Where(x => x.Table.Id == entity.Id)
                .Select(s => new Order(s.Id, s.Waiter, s.PointOfSale, s.Table, s.CreationDate, s.StatusOrder)).ToList();

            foreach (var obj in list)
            {
                obj.SetTable(entity);

                orderRepository.GetInstance().Update(obj);
            }
        }

        private void UpdateOrderItem(Table entity)
        {
            List<OrderItem> list = orderItemRepository.GetInstance().Select().Where(x => x.Order.Table.Id == entity.Id)
                .Select(s => new OrderItem(s.Id, s.Order, s.Product, s.Amount)).ToList();

            foreach (var obj in list)
            {
                obj.Order.SetTable(entity);

                orderItemRepository.GetInstance().Update(obj);
            }
        }
    }
}
