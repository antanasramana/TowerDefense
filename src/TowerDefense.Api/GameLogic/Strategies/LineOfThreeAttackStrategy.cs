using TowerDefense.Api.ArenaAdapter;
using TowerDefense.Api.GameLogic.Grid;
using static TowerDefense.Api.GameLogic.Strategies.StrategyHelper;

namespace TowerDefense.Api.GameLogic.Strategies
{
    public class LineOfThreeAttackStrategy : IAttackStrategy
    {
        public IEnumerable<int> AttackedGridItems(IArenaGrid opponentsArenaGrid, int attackingGridItemId)
        {
            var affectedRow = GetAttackingItemRow(attackingGridItemId);

            IMatrix opponentsMatrix = new ArenaGridAdapter(opponentsArenaGrid);
            var affectedFirstGridItem = GetAffectedGridItems(opponentsMatrix, affectedRow - 1);
            var affectedSecondGridItem = GetAffectedGridItems(opponentsMatrix, affectedRow);
            var affectedThirdGridItem = GetAffectedGridItems(opponentsMatrix, affectedRow + 1);


            var affectedGridItems = new List<int>();
            TryAddAffectedGridItemId(affectedGridItems, affectedFirstGridItem);
            TryAddAffectedGridItemId(affectedGridItems, affectedSecondGridItem);
            TryAddAffectedGridItemId(affectedGridItems, affectedThirdGridItem);

            return affectedGridItems;
        }

        private static int? GetAffectedGridItems(IMatrix opponentsArenaGrid, int targetRow)
        {
            int? affectedItemId = null;
            var opponentsAffectedGridItems = opponentsArenaGrid.GetItemsByRow(targetRow)
                                                               .OrderByDescending(x => x.Id);

            foreach (var gridItem in opponentsAffectedGridItems)
            {
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
