using TowerDefense.Api.Battle.Grid;
using TowerDefense.Api.Constants;
using TowerDefense.Api.Models.Items;

namespace TowerDefense.Api.Strategies
{
    public static class StrategyHelper
    {
        public static IEnumerable<GridItem> GetOpponentGridItemsInFrontOfAttackingItem(List<GridRow> opponentsGridRows, int attackingItemId)
        {
            var affectedGridItems = opponentsGridRows.Where(x => x.RowId == attackingItemId)
                                                     .SelectMany(x => x.GridItems);
            return affectedGridItems;
        }

        public static bool IsItemDamageable(GridItem gridItem)
        {
            return gridItem.Item is not Blank && gridItem.Item is not Placeholder && gridItem.Item is not Bomb;
        }
    }
}
