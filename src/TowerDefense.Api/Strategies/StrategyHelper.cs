using TowerDefense.Api.Battle.Grid;
using TowerDefense.Api.Constants;
using TowerDefense.Api.Models.Items;

namespace TowerDefense.Api.Strategies
{
    public static class StrategyHelper
    {
        public static int GetAttackingItemRow(int attackingGridItemId)
        {
            return attackingGridItemId / Game.MaxGridGridItemsInRow;
        }

        public static IEnumerable<GridItem> GetOpponentGridItemsInFrontOfAttackingItem(int attackingItemRow, GridItem[] opponentGridItems)
        {
            var rowInFrontOfAttackingItem = Enumerable.Range(0, Game.MaxGridGridItemsInRow)
                .Select(x => x + (attackingItemRow * Game.MaxGridGridItemsInRow))
                .Reverse()
                .ToList();

            var affectedGridItems = opponentGridItems.Where(x => rowInFrontOfAttackingItem.Contains(x.Id))
                                                     .OrderByDescending(x => x.Id);
            return affectedGridItems;
        }

        public static bool IsItemDamageable(GridItem gridItem)
        {
            return gridItem.Item is not Blank && gridItem.Item is not Placeholder && gridItem.Item is not Bomb;
        }
    }
}
