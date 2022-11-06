using TowerDefense.Api.GameLogic.Commands;
using TowerDefense.Api.Contracts.Command;

namespace TowerDefense.Api.GameLogic.Handlers
{
    public interface ICommandHandler
    {
        void ExecuteCommandForPlayer(ExecuteCommandRequest commandRequest);
    }
    public class CommandHandler : ICommandHandler
    {
        private readonly IPlayerHandler _playerHandler;
        private readonly ICommandExecutor _commandExecutor;

        public CommandHandler (IPlayerHandler playerHandler, ICommandExecutor commandExecutor)
        {
            _playerHandler = playerHandler;
            _commandExecutor = commandExecutor;
        }

        public void ExecuteCommandForPlayer(ExecuteCommandRequest commandRequest)
        {
            var command = InterpretCommand(commandRequest);
            var player = _playerHandler.GetPlayer(commandRequest.PlayerName);
            _commandExecutor.Execute(player, command);
        }

        public ICommand InterpretCommand(ExecuteCommandRequest commandRequest)
        {
            return commandRequest.CommandType switch
            {
                CommandType.Place => new PlaceCommand(commandRequest.InventoryItemId, commandRequest.GridItemId.Value),
                CommandType.Remove => new RemoveCommand(commandRequest.GridItemId.Value),
                CommandType.Upgrade => new UpgradeCommand(commandRequest.GridItemId.Value),
                CommandType.Undo => new UndoCommand(),
                _ => throw new ArgumentOutOfRangeException()
            };
        }
    }
}
