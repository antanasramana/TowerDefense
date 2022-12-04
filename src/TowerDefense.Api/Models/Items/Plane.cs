using TowerDefense.Api.GameLogic.Builders;
using TowerDefense.Api.GameLogic.Grid;
using TowerDefense.Api.GameLogic.Strategies;

namespace TowerDefense.Api.Models.Items
{
    public class Plane : IItem
    {
        public string Id { get; set; } = nameof(Plane);
        public int Level { get; set; } = 0;
        public ItemType ItemType { get; set; } = ItemType.Plane;
        public IItemStats Stats { get; set; } = new SpecialItemStats();
        public ICollection<string> PowerUps { get; set; } = new List<string>();
        public BaseAttackStrategy AttackStrategy { get; set; } = new HorizontalLineAttackStrategy();

        public IEnumerable<AttackDeclaration> Attack(IArenaGrid opponentsArenaGrid, int attackingGridItemId)
        {
            var affectedGridItemList = AttackStrategy.AttackedGridItems(opponentsArenaGrid, attackingGridItemId);
            return affectedGridItemList.Select(x => new AttackDeclaration() { GridItemId = x, Damage = Stats.Damage, DamageType = DamageType.Fire });
        }

        public IItem Clone()
        {
            return new Plane
            {
                Id = Guid.NewGuid().ToString()
            };
        }
    }
}
