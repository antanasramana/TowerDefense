using TowerDefense.Api.GameLogic.Grid;
using TowerDefense.Api.Models;

namespace TowerDefense.Api.GameLogic.Handlers
{
    public interface IAttackHandler
    {
        Attack HandlePlayerAttacks(IArenaGrid playerArenaGrid, IArenaGrid opponentArenaGrid);
        int PlayerEarnedMoneyAfterAttack(IEnumerable<AttackDeclaration> attackDeclarations);
    }
    public class AttackHandler: IAttackHandler
    {
        public Attack HandlePlayerAttacks(IArenaGrid playerArenaGrid, IArenaGrid opponentArenaGrid)
        {
            var directAttacks = new List<AttackDeclaration>();
            var itemAttacks = new List<AttackDeclaration>();
            foreach (GridItem gridItem in playerArenaGrid.GridItems)
            {
                var attacks = gridItem.Item.Attack(opponentArenaGrid, gridItem.Id);

                if (attacks.Any())
                {
                    itemAttacks.AddRange(gridItem.Item.Attack(opponentArenaGrid, gridItem.Id));
                }
                else
                {
                    directAttacks.Add(new AttackDeclaration { PlayerWasHit = true, Damage = gridItem.Item.Stats.Damage });
                }
            }
            return new Attack{DirectAttackDeclarations = directAttacks, ItemAttackDeclarations = itemAttacks };
        }

        public int PlayerEarnedMoneyAfterAttack(IEnumerable<AttackDeclaration> attackDeclarations)
        {
            return attackDeclarations.Sum(x => x.EarnedMoney);
        }
    }
}
