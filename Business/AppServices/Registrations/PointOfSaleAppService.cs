using Business.Interfaces.Registrations;
using DataTransfer.Requests.Registrations;
using DataTransfer.Responses.Registrations;
using Domain.Entities.Registrations;
using Domain.Repositories.Registrations;
using Library.Resources;

namespace Business.AppServices.Registrations
{
    public class PointOfSaleAppService : CrudAppService<PointOfSale, PointOfSaleRequest, PointOfSaleResponse, IPointOfSaleRepository, IPointOfSaleMapService>, IPointOfSaleAppService
    {
        public PointOfSaleAppService(IPointOfSaleRepository repository, IPointOfSaleMapService mapService) : base(repository, mapService, FieldResource.PointOfSale)
        {
        }
    }
}
