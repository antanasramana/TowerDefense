using TowerDefense.Api.Battle.Grid;
using static TowerDefense.Api.Strategies.StrategyHelper;

namespace TowerDefense.Api.Strategies
{
    public class LineOfThreeAttackStrategy : IAttackStrategy
    {
        public IEnumerable<int> AttackedGridItems(GridItem[] opponentGridItems, int attackingGridItemId)
        {
            int affectedRow = GetAttackingItemRow(attackingGridItemId);
            var affectedGridItems = new List<int>();
            var affectedFirstGridItem = AffectedGridItems(opponentGridItems, affectedRow - 1);
            var affectedSecondGridItem = AffectedGridItems(opponentGridItems, affectedRow);
            var affectedThirdGridItem = AffectedGridItems(opponentGridItems, affectedRow + 1);

            TryAddAffetctedGridItemId(affectedGridItems, affectedFirstGridItem);
            TryAddAffetctedGridItemId(affectedGridItems, affectedSecondGridItem);
            TryAddAffetctedGridItemId(affectedGridItems, affectedThirdGridItem);

            return affectedGridItems;
        }

        private static int? AffectedGridItems(GridItem[] opponentGridItems, int targetRow)
        {
            int? affectedItemId = null;
            var opponentsAffectedGridItems = GetOpponentGridItemsInFrontOfAttackingItem(targetRow, opponentGridItems);

            foreach (var gridItem in opponentsAffectedGridItems)
            {
                if (IsItemDamageble(gridItem))
                {
                    return gridItem.Id;
                }
            }
            return affectedItemId;
        }

        //TODO make it an extension
        private static void TryAddAffetctedGridItemId(List<int> affectedGridItems, int? affectedGridItemId)
        {
            if (!affectedGridItemId.HasValue) return;

            affectedGridItems.Add(affectedGridItemId.Value);
        }
    }
}
