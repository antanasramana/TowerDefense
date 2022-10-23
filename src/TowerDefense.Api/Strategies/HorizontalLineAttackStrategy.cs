using TowerDefense.Api.Battle.Grid;
using TowerDefense.Api.Constants;
using static TowerDefense.Api.Strategies.StrategyHelper;

namespace TowerDefense.Api.Strategies
{
    public class HorizontalLineAttackStrategy : IAttackStrategy
    {
        public IEnumerable<int> AttackedGridItems(AttackInformation attackInformation)
        {
            var affectedGridItems = GetOpponentGridItemsInFrontOfAttackingItem(attackInformation.OpponentsGridItems, attackInformation.AttackingItemRow);

            return affectedGridItems.Select(x => x.Id);
        }
    }
}
