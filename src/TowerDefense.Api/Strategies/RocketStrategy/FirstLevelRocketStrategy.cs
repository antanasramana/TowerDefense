using TowerDefense.Api.Battle.Grid;
using TowerDefense.Api.Models;
using TowerDefense.Api.Models.Player;

namespace TowerDefense.Api.Strategies.RocketStrategy
{
    public class FirstLevelRocketStrategy : IRocketsStrategy
    {
        public List<AttackResult> Attack(GridItem[] opponentGridItems, IPlayer opponent, int damage, int rocketGridId)
        {
            int affectedRow = rocketGridId / 8;
            List<int> affectedGridItems = Enumerable.Range(0, 8).Select(x => x + (affectedRow * 8)).Reverse().ToList();
            GridItem[] opponentsAffectedGridItems = opponentGridItems.Where(x => affectedGridItems.Contains(x.Id))
                                                                     .OrderByDescending(x => x.Id)
                                                                     .ToArray();
            List<AttackResult> result = new List<AttackResult>();
            int leftDamage = damage;
            foreach (GridItem gridItem in opponentsAffectedGridItems)
            {
                AttackResult attackResult = new() { GridItemId = gridItem.Id, Damage = damage};
                leftDamage -= gridItem.Item.Health;
                result.Add(attackResult);
            }
            opponent.Health -= leftDamage;
            return result;
        }
    }
}
