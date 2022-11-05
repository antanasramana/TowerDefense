using TowerDefense.Api.Battle.Grid;
using TowerDefense.Api.Strategies;

namespace TowerDefense.Api.Models.Items
{
    public class Soldier : IItem
    {
        public string Id { get; set; } = nameof(Soldier);
        public int Level { get; set; } = 0;
        public ItemType ItemType { get; set; } = ItemType.Soldier;
        public IItemStats Stats { get; set; } = new RegularDefaultItemStats();
        public ICollection<string> PowerUps { get; set; } = new List<string>();
        public IAttackStrategy AttackStrategy { get; set; } = new FirstInHorizontalLineAttackStrategy();

        public IEnumerable<AttackDeclaration> Attack(IArenaGrid opponentsArenaGrid, int attackingGridItemId)
        {
            var affectedGridItemList = AttackStrategy.AttackedGridItems(opponentsArenaGrid, attackingGridItemId);
            return affectedGridItemList.Select(x => new AttackDeclaration() { GridItemId = x, Damage = Stats.Damage, DamageType = Battle.Builders.DamageType.Projectile });
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
