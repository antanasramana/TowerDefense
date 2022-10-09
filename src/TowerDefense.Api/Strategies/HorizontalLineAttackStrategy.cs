using TowerDefense.Api.Battle.Grid;
using TowerDefense.Api.Constants;
using static TowerDefense.Api.Strategies.StrategyHelper;

namespace TowerDefense.Api.Strategies
{
    public class HorizontalLineAttackStrategy : IAttackStrategy
    {
        public IEnumerable<int> AttackedGridItems(GridItem[] opponentGridItems, int attackingGridItemId)
        {
            var attackingItemRow = attackingGridItemId / Game.MaxGridGridItemsInRow;
            var affectedGridItems = GetOpponentGridItemsInFrontOfAttackingItem(attackingItemRow, opponentGridItems);

            return affectedGridItems.Select(x => x.Id);
        }
    }
}
