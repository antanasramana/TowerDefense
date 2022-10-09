using TowerDefense.Api.Battle.Grid;
using TowerDefense.Api.Strategies;

namespace TowerDefense.Api.Models.Items
{
    public class Placeholder : IItem
    {
        public string Id { get; set; } = nameof(Placeholder);
        public int Price { get; set; } = 0;
        public ItemType ItemType { get; set; } = ItemType.Placeholder;
        public int Health { get; set; } = 0;
        public int Damage { get; set; } = 0;
        public IAttackStrategy AttackStrategy { get; set; } = new NoAttackStrategy();

        public IEnumerable<AttackResult> Attack(GridItem[] opponentGridItems, int attackingGridItemId)
        {
            var affectedGridItemList = AttackStrategy.AttackedGridItems(opponentGridItems, attackingGridItemId);
            return affectedGridItemList.Select(x => new AttackResult() { GridItemId = x, Damage = Damage });
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
