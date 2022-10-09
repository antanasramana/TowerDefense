using TowerDefense.Api.Battle.Grid;

namespace TowerDefense.Api.Strategies
{
    public class NoAttackStrategy : IAttackStrategy
    {
        public IEnumerable<int> AttackedGridItems(GridItem[] opponentGridItems, int attackingGridItemId)
        {
            return new List<int>();
        }
    }
}
