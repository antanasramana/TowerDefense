using TowerDefense.Api.Battle;
using TowerDefense.Api.Battle.Handlers;
using TowerDefense.Api.Repositories;

namespace TowerDefense.Api.Bootstrap
{
    public static class SetupGameEngine
    {
        public static void AddDependencies(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IShop, Shop>();
            serviceCollection.AddTransient<IItemRepository, ItemRepository>();
            serviceCollection.AddTransient<ITurnHandler, TurnHandler>();
            serviceCollection.AddTransient<IBattleOrchestrator, BattleOrchestrator>();
            serviceCollection.AddTransient<IInitialGameSetupHandler, InitialGameSetupHandler>();
        }
    }
}
