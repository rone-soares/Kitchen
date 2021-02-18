using Domain.Entities;
using System.Collections.Generic;

namespace Domain.Repositories
{
    public interface IRepository<TEntity> 
        where TEntity : EntityBase
    {
        List<TEntity> Select();
        List<TEntity> Select(int id);
        int Insert(TEntity request, bool update = false);
        void Update(TEntity request);
        void Delete(int id);

        /*Before need instance the class*/
        RepositoryOnMemory<TEntity> GetInstance();
    }
}
