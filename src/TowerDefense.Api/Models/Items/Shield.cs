using TowerDefense.Api.GameLogic.GameState;
using TowerDefense.Api.GameLogic.Grid;
using TowerDefense.Api.GameLogic.Strategies;

namespace TowerDefense.Api.Models.Items
{
    public class Shield : IItem
    {
        public string Id { get; set; } = nameof(Shield);
        public int Level { get; set; } = 0;
        public ItemType ItemType { get; set; } = ItemType.Shield;
        public ICollection<string> PowerUps { get; set; } = new List<string>();
        public IItemStats Stats { get; set; } = new BasicDefenseItemStats();
        public BaseAttackStrategy AttackStrategy { get; set; } = GameOriginator.Instance.FlyweightFactory.GetStrategy(new NoAttackStrategy());

        public IEnumerable<AttackDeclaration> Attack(IArenaGrid opponentsArenaGrid, int attackingGridItemId)
        {
            var affectedGridItemList = AttackStrategy.AttackedGridItems(opponentsArenaGrid, attackingGridItemId);
            return affectedGridItemList.Select(x => new AttackDeclaration() { GridItemId = x, Damage = Stats.Damage });
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
