using Domain.Entities.Registrations;
using Domain.Repositories.Registrations;
using Domain.Repositories;

namespace Repository.Repositories.Registrations
{
    public class PointOfSaleRepository : RepositoryOnMemory<PointOfSale>, IPointOfSaleRepository
    {
        public PointOfSaleRepository() : base()
        {
        }
    }
}
