using Domain.Entities.Registrations.Enums;
using Library.Resources;
using Library.Service;

namespace Domain.Entities.Registrations
{
    public class PointOfSale : EntityBase
    {
        public int Number { get; protected set; }
        public TypePointOfSaleEnum TypePointOfSale { get; protected set; }

        public PointOfSale() 
        { }

        public PointOfSale(int id, int number, TypePointOfSaleEnum typePointOfSale)
        {
            Id = id;
            Number = ValidationService.SetValue(number, FieldResource.Number, 1, 100);
            TypePointOfSale = typePointOfSale;
        }
    }
}
