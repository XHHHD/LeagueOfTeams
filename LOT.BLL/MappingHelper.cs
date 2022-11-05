using AutoMapper;

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
