using TowerDefense.Api.Contracts.Command;

namespace TowerDefense.Api.GameLogic.Handlers
{
    public interface ICommandHandler
    {
        void ExecuteCommandForPlayer(ExecuteCommandRequest commandRequest);
        void InterpretCommand(InterpretCommandRequest interpretCommandRequest);
    }
    public class CommandHandler : ICommandHandler
    {
        /*
        private readonly IPlayerHandler _playerHandler;

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
            // Constructing tree
            var expressionTree = new ExpressionComposite();
            var expressions = interpretCommandRequest.CommandText.Split(';');
            foreach (var expression in expressions)
            {
                var expressionBranch = new ExpressionComposite();
                var expressionValues = expression.Split(':').Select(s => s.Trim()).ToList();
                if (expressionValues.Count() == 2)
                {
                    var commands = expressionValues[1].Split(',').Select(s => s.Trim());
                    foreach (var command in commands)
                    {
                        var constructedCommand = expressionValues[0] + ' ' +string.Join(' ', command);
                        expressionBranch.Add(new ExpressionLeaf(constructedCommand, _playerHandler, _commandExecutor, _commandInterpreter));
                    }
                }

                expressionTree.Add(expressionBranch);
            }

            expressionTree.Execute(interpretCommandRequest.PlayerName);
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
        }*/
        public void ExecuteCommandForPlayer(ExecuteCommandRequest commandRequest)
        {
            throw new NotImplementedException();
        }

        public void InterpretCommand(InterpretCommandRequest interpretCommandRequest)
        {
            throw new NotImplementedException();
        }
    }
}
