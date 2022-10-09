using TowerDefense.Api.Battle.Grid;
using static TowerDefense.Api.Strategies.StrategyHelper;

namespace TowerDefense.Api.Strategies
{
    public class FirstInHorizontalLineAttackStrategy : IAttackStrategy
    {
        public IEnumerable<int> AttackedGridItems(GridItem[] opponentGridItems, int attackingGridItemId)
        {
            var attackingItemRow = GetAttackingItemRow(attackingGridItemId);
            var possiblyAffectedGridItems = GetOpponentGridItemsInFrontOfAttackingItem(attackingItemRow, opponentGridItems);
            
            var affectedGridItems = new List<int>();

            foreach (var gridItem in possiblyAffectedGridItems)
            {
                if (IsItemDamageable(gridItem))
                {
                    affectedGridItems.Add(gridItem.Id);
                    break;
                }
            }

            return affectedGridItems;
        }
    }
}
