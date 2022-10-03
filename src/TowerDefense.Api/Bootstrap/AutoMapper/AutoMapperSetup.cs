using AutoMapper;

namespace TowerDefense.Api.Bootstrap.AutoMapper
{
    public static class AutoMapperSetup
    {
        public static void SetupAutoMapper(this IServiceCollection serviceCollection)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new InventoryMapProfile());
                cfg.AddProfile(new ShopMapProfile());
                cfg.AddProfile(new ArenaGridMapProfile());
                cfg.AddProfile(new PlayerMapProfile());
            });
            serviceCollection.AddSingleton(config.CreateMapper());
        }
    }
}
