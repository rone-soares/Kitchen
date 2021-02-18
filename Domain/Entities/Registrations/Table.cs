using Library.Resources;
using Library.Service;

namespace Domain.Entities.Registrations
{
    public class Table : EntityBase
    {
        public int Number { get; protected set; }

        public Table()
        { }

        public Table(int id, int number)
        {
            Id = id;
            Number = ValidationService.SetValue(number, FieldResource.Number, 1, 100);
        }
    }
}
