using TowerDefense.Api.GameLogic.ArenaAdapter;
using TowerDefense.Api.GameLogic.Grid;
using TowerDefense.Api.Constants;
using static TowerDefense.Api.GameLogic.Strategies.StrategyHelper;
using TowerDefense.Api.GameLogic.Iterator;

namespace TowerDefense.Api.GameLogic.Strategies
{
    public class DawAttackStrategy : BaseAttackStrategy
    {
        protected override sealed IEnumerable<int> AttackStrategy(IArenaGrid opponentsArenaGrid, int attackingGridItemId)
        {
            var attackingItemRow = GetAttackingItemRow(attackingGridItemId);
            IMatrix opponentsMatrix = new ArenaGridAdapter(opponentsArenaGrid);

            IIterator opponentsItems = opponentsMatrix.GetIterator(attackingItemRow);
            
            var affectedGridItems = new List<int>();
            var centerOfDaw = -1;

            while (opponentsItems.HasMore())
            {
                var gridItem = opponentsItems.GetNext();
                if (IsItemDamageable(gridItem))
                {
                    affectedGridItems.Add(gridItem.Id);
                    centerOfDaw = gridItem.Id % Constants.TowerDefense.MaxGridGridItemsInRow;
                    break;
                }
            }


            if (centerOfDaw != -1)
            {
                TryAddingDawPoints(opponentsMatrix, attackingItemRow - 1, centerOfDaw - 1, affectedGridItems);
                TryAddingDawPoints(opponentsMatrix, attackingItemRow + 1, centerOfDaw - 1, affectedGridItems);
            }

            return affectedGridItems;
        }

        private static void TryAddingDawPoints(IMatrix opponentsMatrix, int x, int y, ICollection<int> affectedGridItems)
        {
            GridItem uperRightGridItem = opponentsMatrix.GetItemByPosition(x, y);

            if (IsItemDamageable(uperRightGridItem))
            {
                affectedGridItems.Add(uperRightGridItem.Id);
            }
        }
        protected sealed override bool isItemOffensive()
        {
            return true;
        }
    }
}
