using TowerDefense.Api.Contracts.Command;
using TowerDefense.Api.GameLogic.Commands;
using TowerDefense.Api.GameLogic.Handlers;
using TowerDefense.Api.GameLogic.Interpreter;

namespace TowerDefense.Api.GameLogic.Composite
{
    public class ExpressionLeaf : IExpressionComponent
    {
        private readonly ICommandInterpreter _commandInterpreter;
        private readonly IPlayerHandler _playerHandler;
        private readonly ICommandExecutor _commandExecutor;

        private string expression { get; set; }
        public ExpressionLeaf(string expression, IPlayerHandler playerHandler, ICommandExecutor commandExecutor, ICommandInterpreter commandInterpreter)
        {
            this.expression = expression;
            this._commandExecutor = commandExecutor;
            this._commandInterpreter = commandInterpreter;
            this._playerHandler = playerHandler;

        }

        public void Execute(string playerName)
        {
            var command = _commandInterpreter.InterpretText(expression);
            if (command == null)
            {
                return;
            }
            var player = _playerHandler.GetPlayer(playerName);
            _commandExecutor.Execute(player, command);
        }

        public bool IsComposite()
        {
            return false;
        }
    }
}
