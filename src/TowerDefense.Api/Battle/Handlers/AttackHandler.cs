using TowerDefense.Api.Battle.Grid;
using TowerDefense.Api.Models;

namespace TowerDefense.Api.Battle.Handlers
{
    public interface IAttackHandler
    {
        IEnumerable<AttackDeclaration> HandlePlayerAttacks(IArenaGrid playerArenaGrid, IArenaGrid opponentArenaGrid);
        int PlayerEarnedMoneyAfterAttack(IEnumerable<AttackDeclaration> attackDeclarations);
    }
    public class AttackHandler: IAttackHandler
    {
        public IEnumerable<AttackDeclaration> HandlePlayerAttacks(IArenaGrid playerArenaGrid, IArenaGrid opponentArenaGrid)
        {
            var result = new List<AttackDeclaration>();
            foreach (GridItem gridItem in playerArenaGrid.GridItems)
            {
                result.AddRange(gridItem.Item.Attack(opponentArenaGrid, gridItem.Id));
            }
            return result;
        }

        public int PlayerEarnedMoneyAfterAttack(IEnumerable<AttackDeclaration> attackDeclarations)
        {
            return attackDeclarations.Sum(x => x.EarnedMoney);
        }
    }
}
