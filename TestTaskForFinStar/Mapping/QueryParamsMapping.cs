using AutoMapper;
using BusinessLogic.Models;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTaskForFinStar.Dto;
using TestTaskForFinStar.Models;

namespace BusinessLogic.Mapping
{
    public class QueryParamsMapping
    {
        public IMapper Mapper { get; }
        public QueryParamsMapping()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<QueryParams, ItemsFilter>();
            });

            Mapper = config.CreateMapper();
        }
    }
}
