using TowerDefense.Api.Models.Player;

namespace TowerDefense.Api.GameLogic.Commands
{
    public interface ICommand
    {
        public bool Execute(IPlayer player);
        public void Undo(IPlayer player);
    }
}
