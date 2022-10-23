using TowerDefense.Api.Battle.Grid;
using static TowerDefense.Api.Strategies.StrategyHelper;

namespace TowerDefense.Api.Strategies
{
    public class FirstInHorizontalLineAttackStrategy : IAttackStrategy
    {
        public IEnumerable<int> AttackedGridItems(AttackInformation attackInformation)
        {
            var possiblyAffectedGridItems = GetOpponentGridItemsInFrontOfAttackingItem(attackInformation.OpponentsGridItems, attackInformation.AttackingItemRow);
            
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
