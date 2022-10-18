using TowerDefense.Api.Models.Player;

namespace TowerDefense.Api.Battle.Command
{
    public interface ICommandExecutor
    {
        void Execute(Command command);
        public void Undo();
    }
    public class CommandExecutor : ICommandExecutor
    {
        private readonly CommandHistory _commandHistory = new CommandHistory();
        private readonly IPlayer player;

        public CommandExecutor(IPlayer player)
        {
            this.player = player;
        }

        public void Execute(Command command)
        {
            command.Execute(player);
            if (command is IRevertable revertable)
            {
                _commandHistory.Push(revertable);
            }
        }

        public void Undo()
        {
            var lastCommand = _commandHistory.Pop();
            if (lastCommand == null) return;
            lastCommand.Undo(player);
        }
    }
}
