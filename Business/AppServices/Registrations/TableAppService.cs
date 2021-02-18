using Business.Interfaces.Registrations;
using DataTransfer.Requests.Registrations;
using DataTransfer.Responses.Registrations;
using Domain.Entities.Registrations;
using Domain.Repositories.Registrations;
using Library.Resources;

namespace Business.AppServices.Registrations
{
    public class TableAppService : CrudAppService<Table, TableRequest, TableResponse, ITableRepository, ITableMapService>, ITableAppService
    {
        public TableAppService(ITableRepository repository, ITableMapService mapService) : base(repository, mapService, FieldResource.Table)
        {
        }
    }
}
