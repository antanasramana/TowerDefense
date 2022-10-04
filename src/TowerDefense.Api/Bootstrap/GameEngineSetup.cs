using TowerDefense.Api.Battle.Handlers;
using TowerDefense.Api.Hubs;

namespace TowerDefense.Api.Bootstrap
{
    public static class GameEngineSetup
    {
        public static void SetupGameEngine(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IShopHandler, ShopHandler>();
            serviceCollection.AddTransient<ITurnHandler, TurnHandler>();
            serviceCollection.AddTransient<IBattleHandler, BattleHandler>();
            serviceCollection.AddTransient<IInitialGameSetupHandler, InitialGameSetupHandler>();
            serviceCollection.AddTransient<IInventoryHandler, InventoryHandler>();
            serviceCollection.AddTransient<INotificationHub, NotificationHub>();
            serviceCollection.AddTransient<IGridHandler, GridHandler>();
            serviceCollection.AddTransient<IPlayerHandler, PlayerHandler>();
        }
    }
}