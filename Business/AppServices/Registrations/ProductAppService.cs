using Business.Interfaces.Registrations;
using DataTransfer.Requests.Registrations;
using DataTransfer.Responses.Registrations;
using Domain.Entities.Registrations;
using Domain.Repositories.Registrations;
using Library.Resources;
using Library.Service;
using System.Collections.Generic;

namespace Business.AppServices.Registrations
{
    public class ProductAppService : CrudAppService<Product, ProductRequest, ProductResponse, IProductRepository, IProductMapService>, IProductAppService
    {
        public ProductAppService(IProductRepository repository, IProductMapService mapService) : base(repository, mapService, FieldResource.Product)
        {
        }

        public List<ProductResponse> SelectByKitchenArea(int idKitchenArea)
        {
            ValidationService.ValidateParameterId(idKitchenArea, FieldResource.KitchenArea);

            return MapEntityListToResponseList(repository.SelectByKitchenArea(idKitchenArea));
        }
    }
}
