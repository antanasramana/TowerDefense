using TowerDefense.Api.Models.Player;

namespace TowerDefense.Api.GameLogic.Commands
{
    public class UndoCommand : ICommand
    {
        public bool Execute(IPlayer player)
        {
            CommandExecutor commandExecutor = new CommandExecutor();
            commandExecutor.Undo(player);

            return false;
        }

        public void Undo(IPlayer player)
        {
            //nothing happens here
        }
    }
}
