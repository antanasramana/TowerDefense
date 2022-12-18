using TowerDefense.Api.GameLogic.Grid;
using TowerDefense.Api.GameLogic.Items.Models;

namespace TowerDefense.Api.GameLogic.Items
{
    public static class ItemHelpers
    {
        public static IItem CreateItemByType(ItemType item)
        {
            return item switch
            {
                ItemType.Blank => new Blank(),
                ItemType.Plane => new Plane(),
                ItemType.Rockets => new Rockets(),
                ItemType.Shield => new Shield(),
                ItemType.Placeholder => new Placeholder(),
                _ => throw new ArgumentOutOfRangeException()
            };
        }
        public static int GetAttackingItemRowId(int attackingGridItemId)
        {
            return attackingGridItemId / Constants.TowerDefense.MaxGridGridItemsInRow;
        }

        public static List<GridItem> GetAttackedRowItems(this IArenaGrid arenaGrid, int rowId)
        {
            return arenaGrid.GridItems
                .Where(x => (int)(x.Id / Constants.TowerDefense.MaxGridGridItemsInRow) == rowId)
                .ToList();
        }

        public static IEnumerable<int> GetAttackedGridItems(IArenaGrid opponentsArenaGrid, int attackingGridItemId)
        {

            var attackerRowId = GetAttackingItemRowId(attackingGridItemId);

            var affectedGridItems = new List<int>();

            var row = opponentsArenaGrid.GetAttackedRowItems(attackerRowId);

            foreach (var gridItem in row)
            {
                if (!IsItemDamageable(gridItem)) continue;

                affectedGridItems.Add(gridItem.Id);
            }

            return affectedGridItems;
        }
        public static bool IsItemDamageable(GridItem gridItem)
        {
            if (gridItem == null) return false;
            return gridItem.Item is not Blank && gridItem.Item is not Placeholder;
        }
    }
}
