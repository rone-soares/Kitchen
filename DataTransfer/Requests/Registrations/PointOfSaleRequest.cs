using Domain.Entities.Registrations.Enums;

namespace DataTransfer.Requests.Registrations
{
    public class PointOfSaleRequest : RequestBase
    {
        public int Number { get; set; }
        public TypePointOfSaleEnum TypePointOfSale { get; set; }
    }
}
