using Domain.Entities.Registrations;
using Domain.Repositories.Registrations;
using Domain.Repositories;

namespace Repository.Repositories.Registrations
{
    public class WaiterRepository : RepositoryOnMemory<Waiter>, IWaiterRepository
    {
        public WaiterRepository() : base()
        {
        }
    }
}
