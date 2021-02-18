using Domain.Entities.Registrations;
using Domain.Repositories.Registrations;
using Domain.Repositories;

namespace Repository.Repositories.Registrations
{
    public class KitchenAreaRepository : RepositoryOnMemory<KitchenArea>, IKitchenAreaRepository
    {
        public KitchenAreaRepository() : base()
        {
        }        
    }
}
