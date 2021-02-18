using Business.Interfaces.Registrations;
using DataTransfer.Requests.Registrations;
using Domain.Entities.Orders;
using Domain.Entities.Registrations;
using Domain.Repositories.Orders;
using Domain.Repositories.Registrations;
using System.Collections.Generic;
using System.Linq;

namespace Business.Services.Registrations
{
    public class KitchenAreaMapService : IKitchenAreaMapService
    {
        private readonly IProductRepository productRepository;
        private readonly IOrderItemRepository orderItemRepository;

        public KitchenAreaMapService(IProductRepository productRepository, IOrderItemRepository orderItemRepository)
        {
            this.productRepository = productRepository;
            this.orderItemRepository = orderItemRepository;
        }

        public KitchenArea MapEntity(KitchenAreaRequest request)
        {
            KitchenArea kitchenArea = new KitchenArea(request.Id, request.Description);

            UpdateProduct(kitchenArea);

            UpdateOrderItem(kitchenArea);

            return kitchenArea;
        }

        private void UpdateProduct(KitchenArea entity)
        {
            List<Product> list = productRepository.GetInstance().Select().Where(x => x.KitchenArea.Id == entity.Id)
                .Select(s => new Product(s.Id, s.Description, s.TimeToFinish, s.KitchenArea)).ToList();

            foreach (var obj in list)
            {
                obj.SetKitchenArea(entity);

                productRepository.GetInstance().Update(obj);
            }
        }

        private void UpdateOrderItem(KitchenArea entity)
        {
            List<OrderItem> list = orderItemRepository.GetInstance().Select().Where(x => x.Product.KitchenArea.Id == entity.Id)
                .Select(s => new OrderItem(s.Id, s.Order, s.Product, s.Amount)).ToList();

            foreach (var obj in list)
            {
                obj.Product.SetKitchenArea(entity);

                orderItemRepository.GetInstance().Update(obj);
            }
        }
    }
}
