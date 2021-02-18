using AutoMapper;
using Business.Interfaces;
using DataTransfer.Requests;
using Domain.Entities;
using Domain.Repositories;
using Library.Interfaces;
using Library.Service;
using System.Collections.Generic;

namespace Business.AppServices
{
    public class CrudAppService<TEntity, TRequest, TResponse, TIRepository, TIMapService> : ICrudAppService<TRequest, TResponse>, IAppServiceBase
        where TEntity : EntityBase
        where TRequest : RequestBase
        where TResponse : class
        where TIRepository : IRepository<TEntity>
        where TIMapService : IMapService<TEntity, TRequest>
    {
        #region "Constructor"        
        protected readonly TIRepository repository;
        protected readonly TIMapService mapService;
        protected readonly string field;
        protected MapperConfiguration mapperConfiguration;

        public CrudAppService(TIRepository repository, TIMapService mapService, string field)
        {
            this.mapService = mapService;
            this.repository = repository;
            this.field = field;

            this.MappingConfiguration();
        }
        #endregion "Constructor"

        #region "Mapping"
        public virtual void MappingConfiguration()
        {
            this.mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TEntity, TResponse>();
            });

            this.mapperConfiguration.AssertConfigurationIsValid();
        }

        protected List<TResponse> MapEntityListToResponseList(List<TEntity> list)
        {
            return mapperConfiguration.CreateMapper()
                .Map<List<TEntity>, List<TResponse>>(list);
        }

        protected TResponse MapEntityToResponse(TEntity obj)
        {
            return mapperConfiguration.CreateMapper()
                .Map<TEntity, TResponse>(obj);
        }

        #endregion "Mapping"

        public List<TResponse> Select()
        {
            var list = repository.GetInstance().Select();

            return MapEntityListToResponseList(list);
        }

        public List<TResponse> Select(int id)
        {
            var list = repository.GetInstance().Select(id);            

            return MapEntityListToResponseList(list);
        }

        public int Insert(TRequest request)
        {
            ValidationService.ValidateExistRequest(request, field);

            var entity = mapService.MapEntity(request);

            return repository.GetInstance().Insert(entity);
        }

        public void Update(TRequest request)
        {
            ValidationService.ValidateParameterId(request.Id, field);

            var entity = mapService.MapEntity(request);

            repository.GetInstance().Update(entity);
        }

        public void Delete(int id)
        {
            ValidationService.ValidateParameterId(id, field);

            repository.GetInstance().Delete(id);
        }
    }
}
