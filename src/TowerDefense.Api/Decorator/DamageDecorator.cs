using TowerDefense.Api.Battle.Grid;
using TowerDefense.Api.Models;
using TowerDefense.Api.Models.Items;

namespace TowerDefense.Api.Decorator
{
    public class DamageDecorator : BaseDecorator
    {
        public DamageDecorator(IItem item) : base(item)
        {
        }

        public override IEnumerable<AttackDeclaration> Attack(GridItem[] opponentGridItems, int attackingGridItemId)
        {
            var attackDeclarations = _item.Attack(opponentGridItems, attackingGridItemId).ToList();
            attackDeclarations.ForEach(x => IncreaseDamage(x));
            return attackDeclarations;
        }

        private static void IncreaseDamage(AttackDeclaration attackDeclaration)
        {
            attackDeclaration.Damage *= 2;
        }
    }
}
