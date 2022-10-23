using TowerDefense.Api.Adapter;
using TowerDefense.Api.Battle.Builders;
using TowerDefense.Api.Battle.Grid;
using TowerDefense.Api.Strategies;

namespace TowerDefense.Api.Models.Items
{
    public class Rockets : IItem
    {
        public string Id { get; set; } = nameof(Rockets);
        public int Price { get; set; } = 100;
        public int Level { get; set; } = 0;

        public ItemType ItemType { get; set; } = ItemType.Rockets;
        public int Health { get; set; } = 25;
        public int Damage { get; set; } = 60;
        public IAttackStrategy AttackStrategy { get; set; } = new FirstInHorizontalLineAttackStrategy();

        public IEnumerable<AttackDeclaration> Attack(GridItem[] opponentGridItems, int attackingGridItemId)
        {
            var attackAdapter = new AttackAdapter(AttackStrategy);
            var affectedGridItemList = attackAdapter.AttackedGridItems(opponentGridItems, attackingGridItemId);
            return affectedGridItemList.Select(x => new AttackDeclaration() { GridItemId = x, Damage = Damage, DamageType = DamageType.Fire });
        }

        public IItem Clone()
        {
            return new Rockets
            {
                Id = Guid.NewGuid().ToString()
            };
        }
    }
}
