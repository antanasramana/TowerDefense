using TowerDefense.Api.Models.Player;

namespace TowerDefense.Api.Battle.Command
{
    public abstract class Command
    {
        protected readonly IPlayer player;

        public Command(IPlayer player)
        {
            this.player = player;
        }
    
        public abstract void Execute();
    }
}
