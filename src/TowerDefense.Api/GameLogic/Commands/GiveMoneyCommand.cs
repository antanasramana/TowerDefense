using TowerDefense.Api.Models.Player;

namespace TowerDefense.Api.GameLogic.Commands
{
    public class GiveMoneyCommand : ICommand
    {
        private readonly int _ammount;

        public GiveMoneyCommand(int ammount)
        {
            _ammount = ammount;
        }
        public bool Execute(IPlayer player)
        {
            player.Money += _ammount;
            return false; // Don't need to add to history
        }

        public void Undo(IPlayer player)
        {
            return;
        }
    }
}
