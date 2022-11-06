using TowerDefense.Api.GameLogic.Grid;

namespace TowerDefense.Api.GameLogic.Strategies
{
    public interface IAttackStrategy
    {
        IEnumerable<int> AttackedGridItems(IArenaGrid opponentsArenaGrid, int attackingGridItemId);
    }
}
