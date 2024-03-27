using AutoMapper;
using BusinessLogic.Mapping;
using DataAccess.Entities;
using DataAccess.Repositories;
using System.Linq.Expressions;
using TestTaskForFinStar.Dto;

namespace BusinessLogic.Services
{
    public class ServiceBase<TEntity, TEntityDto> : IServiceBase<TEntityDto>
        where TEntity : Entity
        where TEntityDto : EntityDto
    {
        private readonly IRepositoryBase<TEntity> _repository;
        protected readonly IMapper Mapper;
        public ServiceBase(IRepositoryBase<TEntity> repository,
            EntityDtoMapping mapper)
        {
            _repository = repository;
            Mapper = mapper.Mapper;
        }

        /// <inheritdoc />
        public void CreateMany(IEnumerable<TEntityDto> models)
        {
            var entities = models.Select(CreateEntity).ToArray();
            _repository.CreateMany(entities);
        }

        /// <inheritdoc />
        public IEnumerable<TEntityDto> GetAll()
        {
            var entities = _repository.GetAll().ToArray();
            return entities.Select(Mapper.Map<TEntity, TEntityDto>);
        }

        /// <inheritdoc />
        public void ClearAll()
        {
            var oldEntities = _repository.GetAll().ToArray();
            if (oldEntities.Any())
            {
                _repository.DeleteMany(oldEntities);
            }
        }

        protected TEntity CreateEntity(TEntityDto model)
        {
            return Mapper.Map<TEntityDto, TEntity>(model);
        }

        protected IEnumerable<TEntityDto> GetEntities(Expression<Func<TEntity, bool>> expression)
        {
            TEntity[] entities;

            var query = _repository.GetAll();

            if (expression != null)
            {
                query = query.Where(expression);
            }

            entities = query.ToArray();

            return entities.Select(Mapper.Map<TEntity, TEntityDto>);
        }
    }
}
