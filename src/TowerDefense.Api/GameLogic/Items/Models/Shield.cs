using TowerDefense.Api.GameLogic.GameState;
using TowerDefense.Api.GameLogic.Grid;
using TowerDefense.Api.GameLogic.Strategies;
using TowerDefense.Api.Models;

namespace TowerDefense.Api.GameLogic.Items.Models
{
    public class Shield : IItem
    {
        public string Id { get; set; } = nameof(Shield);
        public ItemType ItemType { get; set; } = ItemType.Shield;
        public IItemStats Stats { get; set; } = new BasicDefenseItemStats();
        public IEnumerable<AttackDeclaration> Attack(IArenaGrid opponentsArenaGrid, int attackingGridItemId)
        {
            var affectedGridItemList = ItemHelpers.GetAttackedGridItems(opponentsArenaGrid, attackingGridItemId);
            return affectedGridItemList.Select(x => new AttackDeclaration() { GridItemId = x, Damage = Stats.Damage });
        }
    }
}
