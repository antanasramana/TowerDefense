using TowerDefense.Api.Models.Player;

namespace TowerDefense.Api.Battle.Command
{
    public abstract class Command
    {
        public abstract void Execute(IPlayer player);
    }
}
