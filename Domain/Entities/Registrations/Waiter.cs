using Library.Resources;
using Library.Service;

namespace Domain.Entities.Registrations
{
    public class Waiter : EntityBase
    {
        public string Name { get; protected set; }

        public Waiter() 
        { }

        public Waiter(int id, string name)
        {
            Id = id;
            Name = ValidationService.SetDescription(name, FieldResource.Name, 1, 100);
        }
    }
}
