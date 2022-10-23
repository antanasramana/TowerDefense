using TowerDefense.Api.Adapter;
using TowerDefense.Api.Battle.Grid;
using TowerDefense.Api.Strategies;

namespace TowerDefense.Api.Models.Items
{
    public class Rock : IItem
    {
        public string Id { get; set; } = nameof(Rock);
        public int Price { get; set; } = 20;
        public int Level { get; set; } = 0;
        public ItemType ItemType { get; set; } = ItemType.Rock;
        public int Health { get; set; } = 150;
        public int Damage { get; set; } = 0;
        public IAttackStrategy AttackStrategy { get; set; } = new NoAttackStrategy();

        public IEnumerable<AttackDeclaration> Attack(GridItem[] opponentGridItems, int attackingGridItemId)
        {
            var attackAdapter = new AttackInformationAdapter(AttackStrategy);
            var affectedGridItemList = attackAdapter.AttackedGridItems(opponentGridItems, attackingGridItemId);
            return affectedGridItemList.Select(x => new AttackDeclaration() { GridItemId = x, Damage = Damage });
        }

        public IItem Clone()
        {
            return new Rock()
            {
                Id = Guid.NewGuid().ToString()
            };
        }
    }
}
