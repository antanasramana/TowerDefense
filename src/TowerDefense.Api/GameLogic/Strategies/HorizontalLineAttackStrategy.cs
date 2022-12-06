using TowerDefense.Api.GameLogic.ArenaAdapter;
using TowerDefense.Api.GameLogic.Grid;
using TowerDefense.Api.Constants;
using static TowerDefense.Api.GameLogic.Strategies.StrategyHelper;
using TowerDefense.Api.GameLogic.Iterator;

namespace TowerDefense.Api.GameLogic.Strategies
{
    public class HorizontalLineAttackStrategy : BaseAttackStrategy
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
