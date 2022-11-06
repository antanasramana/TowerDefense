using TowerDefense.Api.GameLogic.Grid;

namespace TowerDefense.Api.Strategies
{
    public interface IAttackStrategy
    {
        IEnumerable<int> AttackedGridItems(IArenaGrid opponentsArenaGrid, int attackingGridItemId);
    }
}
