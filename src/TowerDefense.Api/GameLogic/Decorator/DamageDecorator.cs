using TowerDefense.Api.GameLogic.Builders;
using TowerDefense.Api.GameLogic.Grid;
using TowerDefense.Api.GameLogic.Strategies;
using TowerDefense.Api.Models;
using TowerDefense.Api.Models.Items;

namespace TowerDefense.Api.GameLogic.Decorator
{
    public class DamageDecorator : BaseDecorator
    {
        protected override string _powerUpName => "DoubleDamage";

        public DamageDecorator(IItem item) : base(item)
        {
            if (item.Stats is not DefaultZeroItemStats)
            {
                Stats.Damage = item.Stats.Damage * 2;
            }
        }

        public override IEnumerable<AttackDeclaration> Attack(IArenaGrid opponentsArenaGrid, int attackingGridItemId)
        {
            var dawAttackStrategy = new DawAttackStrategy();
            var affectedGridItemList = dawAttackStrategy.AttackedGridItems(opponentsArenaGrid, attackingGridItemId);
            var attackDeclarations = affectedGridItemList.Select(x => new AttackDeclaration() { GridItemId = x, Damage = Stats.Damage, DamageType = DamageType.Fire });
            IncreaseDamage(attackDeclarations);
            return attackDeclarations;
        }

        private void IncreaseDamage(IEnumerable<AttackDeclaration> attackDeclarations)
        {
            attackDeclarations.ToList().ForEach(x => x.Damage = Stats.Damage);
        }
    }
}
