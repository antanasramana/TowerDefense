using TowerDefense.Api.GameLogic.Builders;
using TowerDefense.Api.GameLogic.GameState;
using TowerDefense.Api.GameLogic.Grid;
using TowerDefense.Api.GameLogic.Strategies;

namespace TowerDefense.Api.Models.Items
{
    public class Rockets : IItem
    {
        public string Id { get; set; } = nameof(Rockets);
        public int Level { get; set; } = 0;
        public ItemType ItemType { get; set; } = ItemType.Rockets;
        public IItemStats Stats { get; set; } = new MediumCostHighDamageItemStats();
        public BaseAttackStrategy AttackStrategy { get; set; } = GameOriginator.Instance.FlyweightFactory.GetStrategy(new DawAttackStrategy());
        public ICollection<string> PowerUps { get; set; } = new List<string>();

        public IEnumerable<AttackDeclaration> Attack(IArenaGrid opponentsArenaGrid, int attackingGridItemId)
        {
            var affectedGridItemList = AttackStrategy.AttackedGridItems(opponentsArenaGrid, attackingGridItemId);
            return affectedGridItemList.Select(x => new AttackDeclaration() { GridItemId = x, Damage = Stats.Damage, DamageType = DamageType.Fire });
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
