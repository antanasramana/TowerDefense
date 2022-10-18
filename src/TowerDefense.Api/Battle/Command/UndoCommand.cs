using TowerDefense.Api.Models.Player;

namespace TowerDefense.Api.Battle.Command
{
    public class UndoCommand : Command
    {
        public override void Execute(IPlayer player)
        {
            player.CommandExecutor.Undo();
        }
    }
}
