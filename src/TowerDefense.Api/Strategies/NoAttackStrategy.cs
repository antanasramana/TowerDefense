using TowerDefense.Api.Battle.Grid;
using TowerDefense.Api.Models.Player;

namespace TowerDefense.Api.Strategies
{
    public class NoAttackStrategy : IAttackStrategy
    {
        public List<int> AttackedGridItems(GridItem[] opponentGridItems, IPlayer opponent, int damage, int rocketGridId)
        {
            return new List<int>();
        }
    }
}
