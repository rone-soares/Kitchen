using Domain.Entities.Registrations;
using Library.Resources;
using Library.Service;

namespace Domain.Entities.Orders
{
    public class OrderItem : EntityBase
    {
        public Order Order { get; protected set; }
        public Product Product { get; protected set; }
        public int Amount { get; protected set; }

        public OrderItem() 
        { }

        public OrderItem(int id, Order order, Product product, int amount)
        {
            Id = id;
            Amount = ValidationService.SetValue(amount, FieldResource.Amount, 1, 100);
            SetOrder(order);
            SetProduct(product);
        }

        public void SetOrder(Order order)
        {
            if (order == null)
                ValidationService.ValidateExistRequest(order, FieldResource.Order);

            Order = order;
        }

        public void SetProduct(Product product)
        {
            if (product == null)
                ValidationService.ValidateExistRequest(product, FieldResource.Product);

            Product = product;
        }
    }
}
