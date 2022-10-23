using TowerDefense.Api.Adapter;
using TowerDefense.Api.Battle.Grid;
using TowerDefense.Api.Strategies;

namespace TowerDefense.Api.Models.Items
{
    public class Shield : IItem
    {
        public string Id { get; set; } = nameof(Shield);
        public int Price { get; set; } = 50;
        public int Level { get; set; } = 0;
        public ItemType ItemType { get; set; } = ItemType.Shield;
        public int Health { get; set; } = 50;
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
            return new Shield
            {
                Id = Guid.NewGuid().ToString()
            };
        }
    }
}
