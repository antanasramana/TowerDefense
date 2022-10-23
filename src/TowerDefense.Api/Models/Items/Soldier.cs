using TowerDefense.Api.Adapter;
using TowerDefense.Api.Battle.Grid;
using TowerDefense.Api.Strategies;

namespace TowerDefense.Api.Models.Items
{
    public class Soldier : IItem
    {
        public string Id { get; set; } = nameof(Soldier);
        public int Price { get; set; } = 150;
        public int Level { get; set; } = 0;
        public ItemType ItemType { get; set; } = ItemType.Soldier;
        public int Health { get; set; } = 10;
        public int Damage { get; set; } = 10;
        public IAttackStrategy AttackStrategy { get; set; } = new FirstInHorizontalLineAttackStrategy();

        public IEnumerable<AttackDeclaration> Attack(GridItem[] opponentGridItems, int attackingGridItemId)
        {
            var attackAdapter = new AttackInformationAdapter(AttackStrategy);
            var affectedGridItemList = attackAdapter.AttackedGridItems(opponentGridItems, attackingGridItemId);
            return affectedGridItemList.Select(x => new AttackDeclaration() { GridItemId = x, Damage = Damage, DamageType = Battle.Builders.DamageType.Projectile });
        }

        public IItem Clone()
        {
            return new Soldier
            {
                Id = Guid.NewGuid().ToString()
            };
        }
    }
}
