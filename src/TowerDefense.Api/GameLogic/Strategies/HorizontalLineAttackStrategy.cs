using TowerDefense.Api.ArenaAdapter;
using TowerDefense.Api.GameLogic.Grid;
using TowerDefense.Api.Constants;

namespace TowerDefense.Api.GameLogic.Strategies
{
    public class HorizontalLineAttackStrategy : IAttackStrategy
    {
        public IEnumerable<int> AttackedGridItems(IArenaGrid opponentsArenaGrid, int attackingGridItemId)
        {
            var attackingItemRow = attackingGridItemId / Game.MaxGridGridItemsInRow;
            IMatrix opponentsMatrix = new ArenaGridAdapter(opponentsArenaGrid);
            var affectedGridItems = opponentsMatrix.GetItemsByRow(attackingItemRow)
                                                   .OrderByDescending(x => x.Id);

            return affectedGridItems.Select(x => x.Id);
        }
    }
}
