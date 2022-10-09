using TowerDefense.Api.Battle.Grid;
using TowerDefense.Api.Models.Items;
using TowerDefense.Api.Models.Player;

namespace TowerDefense.Api.Strategies
{
    public class FirstInHorizontalLineAttackStrategy : IAttackStrategy
    {

        public List<int> AttackedGridItems(GridItem[] opponentGridItems, IPlayer opponent, int damage, int rocketGridId)
        {
            int affectedRow = rocketGridId / StrategyConstants.GRIDITEMINLINECOUNT;
            var possiblyAffectedGridItems = Enumerable.Range(0, 8).Select(x => x + (affectedRow * 8)).Reverse().ToList();
            var opponentsAffectedGridItems = opponentGridItems.Where(x => possiblyAffectedGridItems.Contains(x.Id))
                                                         .OrderByDescending(x => x.Id)
                                                         .ToArray();
            var affectedGridItems = new List<int>();
            foreach (GridItem gridItem in opponentsAffectedGridItems)
            {
                if(gridItem.Item is not Blank && gridItem.Item is not Placeholder && gridItem.Item is not Bomb)
                {
                    affectedGridItems.Add(gridItem.Id);
                    break;
                }
            }
            if(affectedGridItems.Count == 0)
            {
                opponent.Health -= damage;
            }
            return affectedGridItems;
        }
    }
}
