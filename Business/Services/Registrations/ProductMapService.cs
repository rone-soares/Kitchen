using Business.Interfaces.Registrations;
using DataTransfer.Requests.Registrations;
using Domain.Entities.Orders;
using Domain.Entities.Registrations;
using Domain.Repositories.Orders;
using Domain.Repositories.Registrations;
using Library.Exceptions;
using Library.Resources;
using System.Collections.Generic;
using System.Linq;

namespace Business.Services.Registrations
{
    public class ProductMapService : IProductMapService
    {
        private readonly IKitchenAreaRepository kitchenAreaRepository;
        private readonly IOrderItemRepository orderItemRepository;

        public ProductMapService(IKitchenAreaRepository kitchenAreaRepository, IOrderItemRepository orderItemRepository)
        {
            this.kitchenAreaRepository = kitchenAreaRepository;
            this.orderItemRepository = orderItemRepository;
        }

        public Product MapEntity(ProductRequest request)
        {
            KitchenArea kitchenArea = ValidateKitchenArea(request.IdKitchenArea);

            Product product = new Product(request.Id, request.Description, request.TimeToFinish, kitchenArea);

            UpdateOrderItem(product);

            return product;
        }
        
        private KitchenArea ValidateKitchenArea(int id)
        {
            KitchenArea kitchenArea = kitchenAreaRepository.GetInstance().Select(id).FirstOrDefault();

            if (kitchenArea == null || kitchenArea.Id <= 0)
                throw new InvalidRequestException(string.Format(MessageResource.InvalidRequest, FieldResource.KitchenArea.ToLower()));

            return kitchenArea;
        }

        private void UpdateOrderItem(Product entity)
        {
            List<OrderItem> list = orderItemRepository.GetInstance().Select().Where(x => x.Product.Id == entity.Id)
                .Select(s => new OrderItem(s.Id, s.Order, s.Product, s.Amount)).ToList();

            foreach (var obj in list)
            {
                obj.SetProduct(entity);

                orderItemRepository.GetInstance().Update(obj);
            }
        }
    }
}
