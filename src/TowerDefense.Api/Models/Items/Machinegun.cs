using TowerDefense.Api.GameLogic.Builders;
using TowerDefense.Api.GameLogic.GameState;
using TowerDefense.Api.GameLogic.Grid;
using TowerDefense.Api.GameLogic.Strategies;

namespace TowerDefense.Api.Models.Items
{
    public class Machinegun : IItem
    {
        public string Id { get; set; } = nameof(Machinegun);
        public int Level { get; set; } = 0;
        public ItemType ItemType { get; set; } = ItemType.Machinegun;
        public IItemStats Stats { get; set; } = new HighDamageItemStats();
        public ICollection<string> PowerUps { get; set; } = new List<string>();
        public BaseAttackStrategy AttackStrategy { get; set; } = GameOriginator.Instance.FlyweightFactory.GetStrategy(new LineOfThreeAttackStrategy());

        public IEnumerable<AttackDeclaration> Attack(IArenaGrid opponentsArenaGrid, int attackingGridItemId)
        {
            var affectedGridItemList = AttackStrategy.AttackedGridItems(opponentsArenaGrid, attackingGridItemId);
            return affectedGridItemList.Select(x => new AttackDeclaration() { GridItemId = x, Damage = Stats.Damage, DamageType = DamageType.Projectile });
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
