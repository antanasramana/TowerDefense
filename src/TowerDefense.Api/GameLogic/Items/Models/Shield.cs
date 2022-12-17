using TowerDefense.Api.GameLogic.Attacks;
using TowerDefense.Api.GameLogic.Grid;

namespace TowerDefense.Api.GameLogic.Items.Models
{
    public class Shield : IItem
    {
        public string Id { get; set; } = nameof(Shield);
        public ItemType ItemType { get; set; } = ItemType.Shield;
        public IItemStats Stats { get; set; } = new BasicDefenseItemStats();
        public IEnumerable<AttackDeclaration> Attack(IArenaGrid opponentsArenaGrid, int attackingGridItemId)
        {
            var affectedGridItemList = new List<int>();
            return affectedGridItemList.Select(x => new AttackDeclaration() { GridItemId = x, Damage = Stats.Damage });
        }
    }
}
