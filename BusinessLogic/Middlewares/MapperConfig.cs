using AutoMapper;
using Core.Concretes.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Middlewares
{
    public static class MapperConfig
    {
        private static IMapper mapper;

        static MapperConfig()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfiles>();
            });
            mapper = config.CreateMapper();
        }

        public static IMapper Mapper => mapper;
    }
}
