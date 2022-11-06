using TowerDefense.Api.ArenaAdapter;
using TowerDefense.Api.GameLogic.Grid;
using static TowerDefense.Api.Strategies.StrategyHelper;

namespace TowerDefense.Api.Strategies
{
    public class FirstInHorizontalLineAttackStrategy : IAttackStrategy
    {
        public IEnumerable<int> AttackedGridItems(IArenaGrid opponentsArenaGrid, int attackingGridItemId)
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
    }
}
