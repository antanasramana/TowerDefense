using TowerDefense.Api.GameLogic.Grid;
using TowerDefense.Api.GameLogic.Iterator;
using static TowerDefense.Api.GameLogic.Strategies.StrategyHelper;

namespace TowerDefense.Api.GameLogic.Strategies
{
    public class FirstInHorizontalLineAttackStrategy : BaseAttackStrategy
    {
        protected override sealed IEnumerable<int> AttackStrategy(IArenaGrid opponentsArenaGrid, int attackingGridItemId)
        {
            var attackingItemRow = GetAttackingItemRow(attackingGridItemId);
            IIterator opponentsItems = opponentsArenaGrid.GetIterator(attackingItemRow);
            
            var affectedGridItems = new List<int>();
            while (opponentsItems.HasMore())
            {
                var gridItem = opponentsItems.GetNext();
                if (IsItemDamageable(gridItem))
                {
                    affectedGridItems.Add(gridItem.Id);
                    break;
                }
            }

            return affectedGridItems;
        }

        protected sealed override bool isItemOffensive()
        {
            return true;
        }
    }
}
