using TowerDefense.Api.Battle.Grid;
using TowerDefense.Api.Models;

namespace TowerDefense.Api.Battle.Handlers
{
    public static class AttackHandler
    {
        public static IEnumerable<AttackDeclaration> HandlePlayerAttacks(IArenaGrid playerArenaGrid, IArenaGrid opponentArenaGrid)
        {
            var result = new List<AttackDeclaration>();
            foreach (GridItem gridItem in playerArenaGrid.GridItems)
            {
                result.AddRange(gridItem.Item.Attack(opponentArenaGrid.GridItems, gridItem.Id));
            }
            return result;
        }

        public static int PlayerEarnedMoneyAfterAttack(IEnumerable<AttackDeclaration> attackDeclarations)
        {
            return attackDeclarations.Sum(x => x.EarnedMoney);
        }
    }
}
