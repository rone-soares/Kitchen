using Business.Interfaces.Registrations;
using DataTransfer.Requests.Registrations;
using DataTransfer.Responses.Registrations;
using Domain.Entities.Registrations;
using Domain.Repositories.Registrations;
using Library.Resources;

namespace Business.AppServices.Registrations
{
    public class KitchenAreaAppService : CrudAppService<KitchenArea, KitchenAreaRequest, KitchenAreaResponse, IKitchenAreaRepository, IKitchenAreaMapService>, IKitchenAreaAppService
    {
        public KitchenAreaAppService(IKitchenAreaRepository repository, IKitchenAreaMapService mapService) : base(repository, mapService, FieldResource.KitchenArea)
        {
        }
    }
}
