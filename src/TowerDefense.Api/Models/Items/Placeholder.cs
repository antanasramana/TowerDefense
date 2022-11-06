using TowerDefense.Api.GameLogic.Grid;
using TowerDefense.Api.GameLogic.Strategies;

namespace TowerDefense.Api.Models.Items
{
    public class Placeholder : IItem
    {
        public string Id { get; set; } = nameof(Placeholder);
        public int Level { get; set; } = 0;
        public ItemType ItemType { get; set; } = ItemType.Placeholder;
        public IItemStats Stats { get; set; } = new DefaultZeroItemStats();
        public ICollection<string> PowerUps { get; set; } = new List<string>();
        public IAttackStrategy AttackStrategy { get; set; } = new NoAttackStrategy();

        public IEnumerable<AttackDeclaration> Attack(IArenaGrid opponentsArenaGrid, int attackingGridItemId)
        {
            var affectedGridItemList = AttackStrategy.AttackedGridItems(opponentsArenaGrid, attackingGridItemId);
            return affectedGridItemList.Select(x => new AttackDeclaration() { GridItemId = x, Damage = Stats.Damage });
        }

        public IItem Clone()
        {
            return new Placeholder
            {
                Id = Guid.NewGuid().ToString()
            };
        }
    }
}
