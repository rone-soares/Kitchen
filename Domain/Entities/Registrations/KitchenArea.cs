using Library.Resources;
using Library.Service;

namespace Domain.Entities.Registrations
{
    public class KitchenArea : EntityBase
    {
        public string Description { get; protected set; }

        public KitchenArea() 
        { }

        public KitchenArea(int id, string description)
        {
            Id = id;
            Description = ValidationService.SetDescription(description, FieldResource.Description, 1, 50);
        }
    }
}
