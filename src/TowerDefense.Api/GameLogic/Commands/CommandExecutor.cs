using TowerDefense.Api.Models.Player;

namespace TowerDefense.Api.GameLogic.Commands
{
    public interface ICommandExecutor
    {
        public void Execute(IPlayer player, ICommand command);
        public void Undo(IPlayer player);
    }
    public class CommandExecutor : ICommandExecutor
    {
        public void Execute(IPlayer player, ICommand command)
        {
            var commandHistory = player.CommandHistory;
            bool wasExecuted = command.Execute(player);
            if (!wasExecuted) return;
            commandHistory.Push(command);
        }

        public void Undo(IPlayer player)
        {
            var commandHistory = player.CommandHistory;
            var lastCommand = commandHistory.Pop();
            if (lastCommand == null) return;
            lastCommand.Undo(player);
        }
    }
}
