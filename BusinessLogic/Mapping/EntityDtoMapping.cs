using AutoMapper;
using DataAccess.Entities;
using TestTaskForFinStar.Dto;

namespace BusinessLogic.Mapping
{
    public class EntityDtoMapping
    {
        public IMapper Mapper { get; }
        public EntityDtoMapping()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Entity, EntityDto>()
                .ReverseMap();

                cfg.CreateMap<Item, ItemDto>()
                .ReverseMap();
            });

            Mapper = config.CreateMapper();
        }
    }
}
