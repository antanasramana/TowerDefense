using TowerDefense.Api.Battle.Grid;
using TowerDefense.Api.Models.Items;
using static TowerDefense.Api.Strategies.StrategyHelper;
namespace TowerDefense.Api.Strategies
{
    public class FirstInHorizontalLineAttackStrategy : IAttackStrategy
    {
        public IEnumerable<int> AttackedGridItems(GridItem[] opponentGridItems, int attackingGridItemId)
        {
            int attackingItemRow = GetAttackingItemRow(attackingGridItemId);
            var possiblyAffectedGridItems = GetOpponentGridItemsInFrontOfAttackingItem(attackingItemRow, opponentGridItems);
            
            var affectedGridItems = new List<int>();

            foreach (var gridItem in possiblyAffectedGridItems)
            {
                if (IsItemDamageble(gridItem))
                {
                    affectedGridItems.Add(gridItem.Id);
                    break;
                }
            }

            return affectedGridItems;
        }
    }
}
