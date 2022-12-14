using TowerDefense.Api.GameLogic.Grid;
using TowerDefense.Api.Constants;
using TowerDefense.Api.Models.Items;

namespace TowerDefense.Api.GameLogic.Strategies
{
    public static class StrategyHelper
    {
        public static int GetAttackingItemRow(int attackingGridItemId)
        {
            return attackingGridItemId / Constants.TowerDefense.MaxGridGridItemsInRow;
        }

        public static int GetAttackingItemColumn(int attackingGridItemId)
        {
            return attackingGridItemId % Constants.TowerDefense.MaxGridGridItemsInRow;
        }

        public static bool IsItemDamageable(GridItem gridItem)
        {
            if (gridItem == null) return false;
            return gridItem.Item is not Blank && gridItem.Item is not Placeholder && gridItem.Item is not Bomb;
        }
    }
}
