using TowerDefense.Api.Battle.Grid;

namespace TowerDefense.Api.Strategies
{
    public class NoAttackStrategy : IAttackStrategy
    {
        public IEnumerable<int> AttackedGridItems(AttackInformation attackInformation)
        {
            return new List<int>();
        }
    }
}
