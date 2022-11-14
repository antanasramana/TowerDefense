using TowerDefense.Api.GameLogic.Commands;
using TowerDefense.Api.Contracts.Command;
using TowerDefense.Api.GameLogic.Interpreter;

namespace TowerDefense.Api.GameLogic.Handlers
{
    public interface ICommandHandler
    {
        void ExecuteCommandForPlayer(ExecuteCommandRequest commandRequest);
        void InterpretCommand(InterpretCommandRequest interpretCommandRequest);
    }
    public class CommandHandler : ICommandHandler
    {
        private readonly IPlayerHandler _playerHandler;
        private readonly ICommandExecutor _commandExecutor;
        private readonly ICommandInterpreter _commandInterpreter;

        public CommandHandler (IPlayerHandler playerHandler, ICommandExecutor commandExecutor, ICommandInterpreter commandInterpreter)
        {
            _playerHandler = playerHandler;
            _commandExecutor = commandExecutor;
            _commandInterpreter = commandInterpreter;
        }

        public void ExecuteCommandForPlayer(ExecuteCommandRequest commandRequest)
        {
            var command = InterpretCommandFromRequest(commandRequest);
            var player = _playerHandler.GetPlayer(commandRequest.PlayerName);
            _commandExecutor.Execute(player, command);
        }

        public void InterpretCommand(InterpretCommandRequest interpretCommandRequest)
        {
            var command = _commandInterpreter.InterpretText(interpretCommandRequest.CommandText);
            if (command == null)
            {
                return;
            }
            var player = _playerHandler.GetPlayer(interpretCommandRequest.PlayerName);
            _commandExecutor.Execute(player, command);
        }

        public ICommand InterpretCommandFromRequest(ExecuteCommandRequest commandRequest)
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
