using TowerDefense.Api.Battle.Grid;

namespace TowerDefense.Api.Strategies
{
    public interface IAttackStrategy
    {
        IEnumerable<int> AttackedGridItems(GridItem[] opponentGridItems, int attackingGridItemId);
    }
}
