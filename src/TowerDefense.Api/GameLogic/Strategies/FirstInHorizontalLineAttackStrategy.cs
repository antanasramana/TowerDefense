using TowerDefense.Api.GameLogic.ArenaAdapter;
using TowerDefense.Api.GameLogic.Grid;
using static TowerDefense.Api.GameLogic.Strategies.StrategyHelper;

namespace TowerDefense.Api.GameLogic.Strategies
{
    public class FirstInHorizontalLineAttackStrategy : BaseAttackStrategy
    {
        protected override sealed IEnumerable<int> AttackStrategy(IArenaGrid opponentsArenaGrid, int attackingGridItemId)
        {
            var attackingItemRow = GetAttackingItemRow(attackingGridItemId);
            IMatrix opponentsMatrix = new ArenaGridAdapter(opponentsArenaGrid);
            var possiblyAffectedGridItems = opponentsMatrix.GetItemsByRow(attackingItemRow)
                                                           .OrderByDescending(x => x.Id);
            
            var affectedGridItems = new List<int>();

            foreach (var gridItem in possiblyAffectedGridItems)
            {
                if (IsItemDamageable(gridItem))
                {
                    affectedGridItems.Add(gridItem.Id);
                    break;
                }
            }

            return affectedGridItems;
        }

        protected sealed override bool isItemOffensive()
        {
            return true;
        }
    }
}
