using Domain.Entities.Registrations;
using Domain.Repositories.Registrations;
using Domain.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Repository.Repositories.Registrations
{
    public class ProductRepository : RepositoryOnMemory<Product>, IProductRepository
    {
        private readonly IKitchenAreaRepository kitchenAreaRepository;

        public ProductRepository(IKitchenAreaRepository kitchenAreaRepository) : base()
        {
            this.kitchenAreaRepository = kitchenAreaRepository;
        }

        public List<Product> SelectByKitchenArea(int idKitchenArea)
        {
            return GetInstance().Select().Where(x => x.KitchenArea.Id == idKitchenArea).ToList();
        }

        /*protected override void SetMapsInQuerySelect(object[] obj, Product entity)
        {
            KitchenArea kitchenArea = obj[1] as KitchenArea;
            kitchenArea = kitchenAreaRepository.Select(new FilterRequest(kitchenArea.Id)).FirstOrDefault();
            entity.SetKitchenArea(kitchenArea);
        }*/
    }
}
