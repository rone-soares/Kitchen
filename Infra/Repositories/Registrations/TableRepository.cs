using Domain.Entities.Registrations;
using Domain.Repositories.Registrations;
using Domain.Repositories;

namespace Repository.Repositories.Registrations
{
    public class TableRepository : RepositoryOnMemory<Table>, ITableRepository
    {
        public TableRepository() : base()
        {
        }
    }
}
