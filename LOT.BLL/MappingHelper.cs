using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOT.BLL
{
    public static class MappingHelper
    {
        private static IMapper _mapper;

        public static IMapper GetMapper()
        {
            if (_mapper is null)
            {
                var configuration = new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile<AutomapperProfile>();
                });

                _mapper = new Mapper(configuration);
            }

            return _mapper;
        }
    }
}
