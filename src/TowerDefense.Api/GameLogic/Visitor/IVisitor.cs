using TowerDefense.Api.GameLogic.Grid;
using TowerDefense.Api.Models;
using TowerDefense.Api.Models.Player;

namespace TowerDefense.Api.GameLogic.Visitor
{
    public interface IVisitor
    {
        void Visit(Inventory inventory);
        void Visit(IPlayer player);
        void Visit(IArenaGrid arenaGrid);
    }
}
