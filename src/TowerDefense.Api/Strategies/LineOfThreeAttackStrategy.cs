using TowerDefense.Api.Battle.Grid;
using static TowerDefense.Api.Strategies.StrategyHelper;

namespace TowerDefense.Api.Strategies
{
    public class LineOfThreeAttackStrategy : IAttackStrategy
    {
        public IEnumerable<int> AttackedGridItems(GridItem[] opponentGridItems, int attackingGridItemId)
        {
            var affectedRow = GetAttackingItemRow(attackingGridItemId);

            var affectedFirstGridItem = GetAffectedGridItems(opponentGridItems, affectedRow - 1);
            var affectedSecondGridItem = GetAffectedGridItems(opponentGridItems, affectedRow);
            var affectedThirdGridItem = GetAffectedGridItems(opponentGridItems, affectedRow + 1);


            var affectedGridItems = new List<int>();
            TryAddAffectedGridItemId(affectedGridItems, affectedFirstGridItem);
            TryAddAffectedGridItemId(affectedGridItems, affectedSecondGridItem);
            TryAddAffectedGridItemId(affectedGridItems, affectedThirdGridItem);

            return affectedGridItems;
        }

        private static int? GetAffectedGridItems(GridItem[] opponentGridItems, int targetRow)
        {
            int? affectedItemId = null;
            var opponentsAffectedGridItems = GetOpponentGridItemsInFrontOfAttackingItem(targetRow, opponentGridItems);

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
