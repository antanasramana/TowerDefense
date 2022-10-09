using TowerDefense.Api.Battle.Grid;
using TowerDefense.Api.Models.Items;
using TowerDefense.Api.Models.Player;

namespace TowerDefense.Api.Strategies
{
    public class VerticalLineOfThreeAttackStrategy : IAttackStrategy
    {

        public List<int> AttackedGridItems(GridItem[] opponentGridItems, IPlayer opponent, int damage, int rocketGridId)
        {
            int affectedRow = rocketGridId / StrategyConstants.GRIDITEMINLINECOUNT;
            var affectedGridItems = new List<int>();
            affectedGridItems = AffectedGridItems(opponentGridItems, affectedGridItems, affectedRow - 1);
            affectedGridItems = AffectedGridItems(opponentGridItems, affectedGridItems, affectedRow);
            affectedGridItems = AffectedGridItems(opponentGridItems, affectedGridItems, affectedRow + 1);
            var playerAttackCount = StrategyConstants.VERTICALLINEATTACKCOUNT - affectedGridItems.Count;
            while(playerAttackCount != 0)
            {
                opponent.Health -= damage;
                playerAttackCount--;
            }
            return affectedGridItems;
        }
        private List<int> AffectedGridItems(GridItem[] opponentGridItems, List<int> affectedGridItems, int targetRow)
        {
            var possiblyAffectedGridItems = Enumerable.Range(0, 8).Select(x => x + (targetRow * 8)).Reverse().ToList();
            var opponentsAffectedGridItems = opponentGridItems.Where(x => possiblyAffectedGridItems.Contains(x.Id))
                                                         .OrderByDescending(x => x.Id)
                                                         .ToArray();
            foreach (var gridItem in opponentsAffectedGridItems)
            {
                if (gridItem.Item is not Blank && gridItem.Item is not Placeholder && gridItem.Item is not Bomb)
                {
                    affectedGridItems.Add(gridItem.Id);
                    break;
                }
            }
            return affectedGridItems;
        }
    }
}
