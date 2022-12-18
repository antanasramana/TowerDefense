using TowerDefense.Api.GameLogic.Attacks;
using TowerDefense.Api.GameLogic.Grid;
using TowerDefense.Api.GameLogic.Items.Models;

namespace TowerDefense.Api.GameLogic.Handlers
{
    public interface IAttackHandler
    {
        Attack HandlePlayerAttacks(IArenaGrid playerArenaGrid, IArenaGrid opponentArenaGrid);
    }
    public class AttackHandler: IAttackHandler
    {
        public Attack HandlePlayerAttacks(IArenaGrid playerArenaGrid, IArenaGrid opponentArenaGrid)
        {
            var directAttacks = new List<AttackDeclaration>();
            var itemAttacks = new List<AttackDeclaration>();

            var items = playerArenaGrid.GridItems
                .Where(x => x.Item is not Blank)
                .Where(x => x.Item is not Placeholder)
                .ToList();

            foreach (GridItem gridItem in items)
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
    }
}
