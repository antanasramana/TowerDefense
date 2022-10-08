using TowerDefense.Api.Battle.Grid;
using TowerDefense.Api.Models;
using TowerDefense.Api.Models.Player;

namespace TowerDefense.Api.Strategies.RocketStrategy
{
    public interface IRocketsStrategy
    {
        List<AttackResult> Attack(GridItem[] opponentGridItems, IPlayer opponent, int damage, int rocketGridId);
    }
}
