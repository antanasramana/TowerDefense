using TowerDefense.Api.GameLogic.Commands;
using TowerDefense.Api.GameLogic.Handlers;
using TowerDefense.Api.GameLogic.Mediator;
using TowerDefense.Api.GameLogic.Interpreter;
using TowerDefense.Api.Hubs;

namespace TowerDefense.Api.Bootstrap
{
    public static class GameEngineSetup
    {
        public static void SetupGameEngine(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IShopHandler, ShopHandler>();
            serviceCollection.AddTransient<ITurnHandler, TurnHandler>();
            serviceCollection.AddTransient<IBattleHandlerFacade, BattleHandlerFacade>();
            serviceCollection.AddTransient<IInitialGameSetupHandler, InitialGameSetupHandler>();
            serviceCollection.AddTransient<IInventoryHandler, InventoryHandler>();
            serviceCollection.AddTransient<INotificationHub, NotificationHub>();
            serviceCollection.AddTransient<IGridHandler, GridHandler>();
            serviceCollection.AddTransient<IPlayerHandler, PlayerHandler>();
            serviceCollection.AddTransient<ICommandHandler, CommandHandler>();
            serviceCollection.AddTransient<ICommandExecutor, CommandExecutor>();
            serviceCollection.AddTransient<ICommandInterpreter, CommandInterpreter>();
            serviceCollection.AddTransient<IAttackHandler, AttackHandler>();
            serviceCollection.AddTransient<IGameMediator, GameMediator>();
            serviceCollection.AddTransient<IPerkHandler, PerkHandler>();
        }
    }
}