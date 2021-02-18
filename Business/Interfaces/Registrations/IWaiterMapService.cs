using DataTransfer.Requests.Registrations;
using Domain.Entities.Registrations;

namespace Business.Interfaces.Registrations
{
    public interface IWaiterMapService : IMapService<Waiter, WaiterRequest>
    {
    }
}
