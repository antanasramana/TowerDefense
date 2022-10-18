using TowerDefense.Api.Models.Player;

namespace TowerDefense.Api.Battle.Command
{
    public interface IRevertable
    {
        void Undo(IPlayer player);
    }
}
