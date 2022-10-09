using TowerDefense.Api.Battle.Grid;
using TowerDefense.Api.Models.Player;
using TowerDefense.Api.Models;

namespace TowerDefense.Api.Strategies
{
    public interface IAttackStrategy
    {
        List<int> AttackedGridItems(GridItem[] opponentGridItems, IPlayer opponent, int damage, int rocketGridId);
    }
}
