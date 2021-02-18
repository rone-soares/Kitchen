using Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Repositories
{
    public class RepositoryOnMemory<TEntity> : IRepository<TEntity>
        where TEntity : EntityBase
    {
        #region "Constructor"
        protected RepositoryOnMemory()
        {
            ListEntity = new List<TEntity>();
        }

        protected static volatile RepositoryOnMemory<TEntity> instance;
        protected static object syncRoot = new object();
        protected static object syncEntity = new object();

        protected List<TEntity> ListEntity;


        public RepositoryOnMemory<TEntity> GetInstance()
        {
            return Instance;
        }

        public static RepositoryOnMemory<TEntity> Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new RepositoryOnMemory<TEntity>();
                    }
                }

                return instance;
            }
        }

        #endregion "Constructor"


        public int Insert(TEntity entity, bool update = false)
        {
            lock (syncEntity)
            {
                if (!update)
                {
                    int newId = 1;

                    if (ListEntity.Count() > 0)
                        newId = ListEntity.Max(m => m.Id) + newId;

                    entity.Id = newId;
                }                

                ListEntity.Add(entity);

                return entity.Id;
            }
        }

        public void Delete(int id)
        {
            lock (syncEntity)
            {
                ListEntity.Remove(ListEntity.Where(x => x.Id == id).FirstOrDefault());
            }
        }

        public void Update(TEntity entity)
        {
            lock (syncEntity)
            {

                Delete(entity.Id);
                Insert(entity, true);
            }
        }

        public List<TEntity> Select()
        {
            return ListEntity;
        }

        public List<TEntity> Select(int id)
        {
            var list = ListEntity.Where(x => x.Id == id).ToList();
            
            return list;
        }
    }
}
