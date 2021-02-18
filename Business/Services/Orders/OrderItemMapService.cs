using Business.Interfaces.Orders;
using DataTransfer.Requests.Orders;
using Domain.Entities.Orders;
using Domain.Entities.Registrations;
using Domain.Repositories.Orders;
using Domain.Repositories.Registrations;
using Library.Exceptions;
using Library.Resources;
using System.Linq;

namespace Business.Services.Orders
{
    public class OrderItemMapService : IOrderItemMapService
    {
        private readonly IProductRepository productRepository;
        private readonly IOrderRepository orderRepository;

        public OrderItemMapService(IProductRepository productRepository, IOrderRepository orderRepository)
        {
            this.productRepository = productRepository;
            this.orderRepository = orderRepository;
        }

        public OrderItem MapEntity(OrderItemRequest request)
        {
            Product product = ValidateProduct(request.IdProduct);
            Order order = ValidateOrder(request.IdOrder);

            OrderItem orderItem = new OrderItem(request.Id, order, product, request.Amount);

            return orderItem;
        }

        private Product ValidateProduct(int id)
        {
            Product product = productRepository.GetInstance().Select(id).FirstOrDefault();

            if (product == null || product.Id <= 0)
                throw new InvalidRequestException(string.Format(MessageResource.InvalidRequest, FieldResource.Product.ToLower()));

            return product;
        }

        private Order ValidateOrder(int id)
        {
            Order order = orderRepository.GetInstance().Select(id).FirstOrDefault();

            if (order == null || order.Id <= 0)
                throw new InvalidRequestException(string.Format(MessageResource.InvalidRequest, FieldResource.Order.ToLower()));

            return order;
        }        
    }
}
