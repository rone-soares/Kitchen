using Business.Interfaces.Registrations;
using DataTransfer.Requests.Registrations;
using DataTransfer.Responses.Registrations;
using Domain.Entities.Registrations;
using Domain.Repositories.Registrations;
using Library.Resources;

namespace Business.AppServices.Registrations
{
    public class WaiterAppService : CrudAppService<Waiter, WaiterRequest, WaiterResponse, IWaiterRepository, IWaiterMapService>, IWaiterAppService
    {
        public WaiterAppService(IWaiterRepository repository, IWaiterMapService mapService) : base(repository, mapService, FieldResource.Waiter)
        {
        }
    }
}
