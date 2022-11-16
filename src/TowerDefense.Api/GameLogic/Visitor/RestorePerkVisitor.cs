using TowerDefense.Api.GameLogic.Grid;
using TowerDefense.Api.Models;
using TowerDefense.Api.Models.Player;

namespace TowerDefense.Api.GameLogic.Visitor
{
    public class RestorePerkVisitor : IVisitor
    {
        public void Visit(Inventory inventory)
        {
            throw new NotImplementedException();
        }

        public void Visit(IPlayer player)
        {
            throw new NotImplementedException();
        }

        public void Visit(IArenaGrid arenaGrid)
        {
            throw new NotImplementedException();
        }
    }
}
