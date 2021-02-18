using DataTransfer.Requests.Registrations;
using DataTransfer.Responses.Registrations;
using System.Collections.Generic;

namespace Business.Interfaces.Registrations
{
    public interface IProductAppService : ICrudAppService<ProductRequest, ProductResponse>
    {
        List<ProductResponse> SelectByKitchenArea(int idKitchenArea);
    }
}
