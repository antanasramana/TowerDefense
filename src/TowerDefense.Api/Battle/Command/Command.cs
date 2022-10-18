using TowerDefense.Api.Models.Player;

namespace TowerDefense.Api.Battle.Command
{
    public abstract class Command
    {
        protected abstract bool canBeUndone { get; }
        public bool CanBeUndone => canBeUndone;
        private readonly IPlayer player;

        public Command(IPlayer player)
        {
            this.player = player;
        }
    
        public abstract void Execute();
    }
}
