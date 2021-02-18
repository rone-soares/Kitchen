using Library.Resources;
using Library.Service;

namespace Domain.Entities.Registrations
{
    public class Product : EntityBase
    {
        public string Description { get; protected set; }
        public int TimeToFinish { get; protected set; }
        public KitchenArea KitchenArea { get; protected set; }

        public Product()
        { }

        public Product(int id, string description, int timeToFinish, KitchenArea kitchenArea)
        {
            Id = id;
            Description = ValidationService.SetDescription(description, FieldResource.Description, 1, 300);
            TimeToFinish = ValidationService.SetValue(timeToFinish, FieldResource.TimeToFinish, 1, 60);
            SetKitchenArea(kitchenArea);
        }

        public void SetKitchenArea(KitchenArea kitchenArea)
        {
            if (kitchenArea == null)
                ValidationService.ValidateExistRequest(kitchenArea, FieldResource.KitchenArea);

            KitchenArea = kitchenArea;
        }
    }
}
