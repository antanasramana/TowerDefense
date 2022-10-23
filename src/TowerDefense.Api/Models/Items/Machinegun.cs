using TowerDefense.Api.Battle.Builders;
using TowerDefense.Api.Battle.Grid;
using TowerDefense.Api.Strategies;

namespace TowerDefense.Api.Models.Items
{
    public class Machinegun : IItem
    {
        public string Id { get; set; } = nameof(Machinegun);
        public int Price { get; set; } = 100;
        public int Level { get; set; } = 0;
        public ItemType ItemType { get; set; } = ItemType.Machinegun;
        public int Health { get; set; } = 50;
        public int Damage { get; set; } = 100;
        public IAttackStrategy AttackStrategy { get; set; } = new LineOfThreeAttackStrategy();

        public IEnumerable<AttackDeclaration> Attack(AttackInformation attackInformation)
        {
            var affectedGridItemList = AttackStrategy.AttackedGridItems(attackInformation);
            return affectedGridItemList.Select(x => new AttackDeclaration() { GridItemId = x, Damage = Damage, DamageType = DamageType.Projectile });
        }

        public IItem Clone()
        {
            return new Machinegun
            {
                Id = Guid.NewGuid().ToString()
            };
        }

    }
}
