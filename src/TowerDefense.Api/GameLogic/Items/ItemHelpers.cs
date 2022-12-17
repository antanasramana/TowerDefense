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
        public static int GetAttackingItemRow(int attackingGridItemId)
        {
            return attackingGridItemId / Constants.TowerDefense.MaxGridGridItemsInRow;
        }

        public static int GetAttackingItemColumn(int attackingGridItemId)
        {
            return attackingGridItemId % Constants.TowerDefense.MaxGridGridItemsInRow;
        }
        public static IEnumerable<int> GetAttackedGridItems(IArenaGrid opponentsArenaGrid, int attackingGridItemId)
        {
            /*
            var attackingItemRow = GetAttackingItemRow(attackingGridItemId);
            IIterator opponentsItems = opponentsArenaGrid.GetIterator(attackingItemRow);

            var affectedGridItems = new List<int>();
            while (opponentsItems.HasMore())
            {
                var gridItem = opponentsItems.GetNext();
                if (IsItemDamageable(gridItem))
                {
                    affectedGridItems.Add(gridItem.Id);
                    break;
                }
            }

            return affectedGridItems;
            */
            return null;
        }
    }
}
