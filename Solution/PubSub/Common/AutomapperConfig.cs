using AutoMapper;

namespace Common
{
    public static class AutomapperConfig
    {
        public static IMapper Initialize()
        {
            var mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>(); // Assuming MappingProfile is the profile where mappings are defined
            });

            return mapperConfiguration.CreateMapper();
        }
    }
}
