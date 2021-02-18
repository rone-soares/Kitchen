using Domain.Entities.Registrations;
using System.Collections.Generic;

namespace Domain.Repositories.Registrations
{
    public interface IProductRepository : IRepository<Product>
    {
        List<Product> SelectByKitchenArea(int idKitchenArea);
    }
}
