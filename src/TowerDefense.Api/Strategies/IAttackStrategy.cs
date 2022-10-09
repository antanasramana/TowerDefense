using TowerDefense.Api.Battle.Grid;
using TowerDefense.Api.Models.Player;
using TowerDefense.Api.Models;

namespace TowerDefense.Api.Strategies
{
    public interface IAttackStrategy
    {
        IEnumerable<int> AttackedGridItems(GridItem[] opponentGridItems, int attackingGridItemId);
    }
}
