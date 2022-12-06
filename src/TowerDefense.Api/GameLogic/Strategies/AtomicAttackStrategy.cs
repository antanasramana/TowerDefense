using TowerDefense.Api.GameLogic.Grid;

namespace TowerDefense.Api.GameLogic.Strategies
{
    public class AtomicAttackStrategy : IAttackStrategy
    {
        public IEnumerable<int> AttackedGridItems(IArenaGrid opponentsArenaGrid, int attackingGridItemId)
        {
            return opponentsArenaGrid.GridItems.Select(x => x.Id);
        }
    }
}
