using TowerDefense.Api.Battle.Grid;
using TowerDefense.Api.Models.Player;

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
