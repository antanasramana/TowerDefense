using TowerDefense.Api.GameLogic.Grid;
using TowerDefense.Api.GameLogic.Items.Models;

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
    }
}
