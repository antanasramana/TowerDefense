using TowerDefense.Api.Battle.Grid;
using TowerDefense.Api.Models;
using TowerDefense.Api.Models.Items;

namespace TowerDefense.Api.Decorator
{
    public class DamageDecorator : BaseDecorator
    {
        protected override string _powerUpName => "DoubleDamage";

        public DamageDecorator(IItem item) : base(item)
        {
            Damage = item.Damage * 2;
        }

        public override IEnumerable<AttackDeclaration> Attack(IArenaGrid opponentsArenaGrid, int attackingGridItemId)
        {
            var attackDeclarations = _item.Attack(opponentsArenaGrid, attackingGridItemId).ToList();
            IncreaseDamage(attackDeclarations);
            return attackDeclarations;
        }

        private void IncreaseDamage(IEnumerable<AttackDeclaration> attackDeclarations)
        {
            attackDeclarations.ToList().ForEach(x => x.Damage = Damage);
        }
    }
}
