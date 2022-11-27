using TowerDefense.Api.GameLogic.ArenaAdapter;
using TowerDefense.Api.GameLogic.Grid;
using TowerDefense.Api.GameLogic.Iterator;
using static TowerDefense.Api.GameLogic.Strategies.StrategyHelper;

namespace TowerDefense.Api.GameLogic.Strategies
{
    public class LineOfThreeAttackStrategy : IAttackStrategy
    {
        public IEnumerable<int> AttackedGridItems(IArenaGrid opponentsArenaGrid, int attackingGridItemId)
        {
            var affectedRow = GetAttackingItemRow(attackingGridItemId);

            var affectedFirstGridItem = GetAffectedGridItems(opponentsArenaGrid, affectedRow - 1);
            var affectedSecondGridItem = GetAffectedGridItems(opponentsArenaGrid, affectedRow);
            var affectedThirdGridItem = GetAffectedGridItems(opponentsArenaGrid, affectedRow + 1);


            var affectedGridItems = new List<int>();
            TryAddAffectedGridItemId(affectedGridItems, affectedFirstGridItem);
            TryAddAffectedGridItemId(affectedGridItems, affectedSecondGridItem);
            TryAddAffectedGridItemId(affectedGridItems, affectedThirdGridItem);

            return affectedGridItems;
        }

        private static int? GetAffectedGridItems(IArenaGrid opponentsArenaGrid, int targetRow)
        {
            int? affectedItemId = null;

            IIterator opponentsItems = opponentsArenaGrid.GetIterator(targetRow);

            while (opponentsItems.HasMore())
            {
                var gridItem = opponentsItems.GetNext();
                if (IsItemDamageable(gridItem))
                {
                    return gridItem.Id;
                }
            }

            return affectedItemId;
        }

        private static void TryAddAffectedGridItemId(ICollection<int> affectedGridItems, int? affectedGridItemId)
        {
            if (!affectedGridItemId.HasValue) return;

            affectedGridItems.Add(affectedGridItemId.Value);
        }
    }
}
