using TowerDefense.Api.GameLogic.Grid;

namespace TowerDefense.Api.GameLogic.Strategies
{
    public class AtomicAttackStrategy : BaseAttackStrategy
    {
        protected override sealed IEnumerable<int> AttackStrategy(IArenaGrid opponentsArenaGrid, int attackingGridItemId)
        {
            return opponentsArenaGrid.GridItems.Select(x => x.Id);
        }
    }
}
