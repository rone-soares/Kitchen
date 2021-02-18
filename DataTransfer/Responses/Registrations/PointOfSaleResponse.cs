using Domain.Entities.Registrations.Enums;

namespace DataTransfer.Responses.Registrations
{
    public class PointOfSaleResponse
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public TypePointOfSaleEnum TypePointOfSale { get; set; }
    }
}
