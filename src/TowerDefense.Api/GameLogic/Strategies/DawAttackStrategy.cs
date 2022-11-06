using TowerDefense.Api.GameLogic.ArenaAdapter;
using TowerDefense.Api.GameLogic.Grid;
using TowerDefense.Api.Constants;
using static TowerDefense.Api.Strategies.StrategyHelper;

namespace TowerDefense.Api.GameLogic.Strategies
{
    public class DawAttackStrategy : IAttackStrategy
    {
        public IEnumerable<int> AttackedGridItems(IArenaGrid opponentsArenaGrid, int attackingGridItemId)
        {
            var attackingItemRow = GetAttackingItemRow(attackingGridItemId);
            IMatrix opponentsMatrix = new ArenaGridAdapter(opponentsArenaGrid);
            var possiblyAffectedGridItems = opponentsMatrix.GetItemsByRow(attackingItemRow)
                                                           .OrderByDescending(x => x.Id);
            
            var affectedGridItems = new List<int>();
            var centerOfDaw = -1;

            foreach (var gridItem in possiblyAffectedGridItems)
            {
                if (IsItemDamageable(gridItem))
                {
                    affectedGridItems.Add(gridItem.Id);
                    centerOfDaw = gridItem.Id % Game.MaxGridGridItemsInRow;
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
    }
}
