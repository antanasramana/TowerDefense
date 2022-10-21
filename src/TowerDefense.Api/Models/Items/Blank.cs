using TowerDefense.Api.Battle.Grid;
using TowerDefense.Api.Strategies;

namespace TowerDefense.Api.Models.Items
{
    public class Blank : IItem
    {
        public string Id { get; set; } = nameof(Blank);
        public int Price { get; set; } = 0;
        public int Level { get; set; } = 0;
        public ItemType ItemType { get; set; } = ItemType.Blank;
        public int Health { get; set; } = 0;
        public int Damage { get; set; } = 0;
        public IAttackStrategy AttackStrategy { get; set; } = new NoAttackStrategy();

        public IEnumerable<AttackDeclaration> Attack(GridItem[] opponentGridItems, int attackingGridItemId)
        {
            var affectedGridItemList = AttackStrategy.AttackedGridItems(opponentGridItems, attackingGridItemId);
            return affectedGridItemList.Select(x => new AttackDeclaration() { GridItemId = x, Damage = Damage });
        }

        public IItem Clone()
        {
            return new Blank()
            {
                Id = Guid.NewGuid().ToString()
            };
        }
    }
}
