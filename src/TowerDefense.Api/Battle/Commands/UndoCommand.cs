using TowerDefense.Api.Models.Player;

namespace TowerDefense.Api.Battle.Commands
{
    public class UndoCommand : ICommand
    {
        public bool Execute(IPlayer player)
        {
            var commandExecutor = new CommandExecutor();
            commandExecutor.Undo(player);

            return false;
        }

        public void Undo(IPlayer player)
        {
            return;
        }
    }
}
