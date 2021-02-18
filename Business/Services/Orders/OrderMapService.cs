using Business.Interfaces.Orders;
using DataTransfer.Requests.Orders;
using Domain.Entities.Orders;
using Domain.Entities.Registrations;
using Domain.Repositories.Orders;
using Domain.Repositories.Registrations;
using Library.Exceptions;
using Library.Resources;
using System.Collections.Generic;
using System.Linq;

namespace Business.Services.Orders
{
    public class OrderMapService : IOrderMapService
    {
        private readonly IOrderRepository orderRepository;
        private readonly IOrderItemRepository orderItemRepository;
        private readonly IWaiterRepository waiterRepository;
        private readonly IPointOfSaleRepository pointOfSaleRepository;
        private readonly ITableRepository tableRepository;

        public OrderMapService(IOrderRepository orderRepository, IWaiterRepository waiterRepository, 
            IPointOfSaleRepository pointOfSaleRepository, ITableRepository tableRepository,
            IOrderItemRepository orderItemRepository)
        {
            this.orderRepository = orderRepository;
            this.waiterRepository = waiterRepository;
            this.pointOfSaleRepository = pointOfSaleRepository;
            this.tableRepository = tableRepository;
            this.orderItemRepository = orderItemRepository;
        }

        public Order MapEntity(OrderRequest request)
        {
            Waiter waiter = ValidateWaiter(request.IdWaiter);
            PointOfSale pointOfSale = ValidatePointOfSale(request.IdPointOfSale);
            Table table = ValidateTable(request.IdTable);

            Order order = new Order(request.Id, waiter, pointOfSale, table, request.CreationDate, request.StatusOrder);

            UpdateOrderItem(order);

            return order;
        }

        private Waiter ValidateWaiter(int id)
        {
            Waiter waiter = waiterRepository.GetInstance().Select(id).FirstOrDefault();

            if (waiter == null || waiter.Id <= 0)
                throw new InvalidRequestException(string.Format(MessageResource.InvalidRequest, FieldResource.Waiter.ToLower()));

            return waiter;
        }

        private PointOfSale ValidatePointOfSale(int id)
        {
            PointOfSale pointOfSale = pointOfSaleRepository.GetInstance().Select(id).FirstOrDefault();

            if (pointOfSale == null || pointOfSale.Id <= 0)
                throw new InvalidRequestException(string.Format(MessageResource.InvalidRequest, FieldResource.PointOfSale.ToLower()));

            return pointOfSale;
        }

        private Table ValidateTable(int id)
        {
            Table table = tableRepository.GetInstance().Select(id).FirstOrDefault();

            if (table == null || table.Id <= 0)
                throw new InvalidRequestException(string.Format(MessageResource.InvalidRequest, FieldResource.Table.ToLower()));

            return table;
        }

        private void UpdateOrderItem(Order entity)
        {
            List<OrderItem> list = orderItemRepository.GetInstance().Select().Where(x => x.Order.Id == entity.Id)
                .Select(s => new OrderItem(s.Id, s.Order, s.Product, s.Amount)).ToList();

            foreach (var obj in list)
            {
                obj.SetOrder(entity);

                orderItemRepository.GetInstance().Update(obj);
            }
        }
    }
}
