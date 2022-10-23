using TowerDefense.Api.Battle.Grid;

namespace TowerDefense.Api.Strategies
{
    public class NoAttackStrategy : IAttackStrategy
    {
        public IEnumerable<int> AttackedGridItems(IArenaGrid opponentsArenaGrid, int attackingGridItemId)
        {
            return new List<int>();
        }
    }
}
