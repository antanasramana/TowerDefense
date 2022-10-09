using TowerDefense.Api.Battle.Grid;
using TowerDefense.Api.Models.Player;

namespace TowerDefense.Api.Strategies
{
    public class HorizontalLineAttackStrategy : IAttackStrategy
    {
        public List<int> AttackedGridItems(GridItem[] opponentGridItems, IPlayer opponent, int damage, int rocketGridId)
        {
            int affectedRow = rocketGridId / StrategyConstants.GRIDITEMINLINECOUNT;
            var affectedGridItems = Enumerable.Range(0, 8).Select(x => x + (affectedRow * 8)).Reverse().ToList();

            opponent.Health -= damage;
            return affectedGridItems;
        }
    }
}
