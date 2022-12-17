using TowerDefense.Api.GameLogic.Grid;
using TowerDefense.Api.Models;

namespace TowerDefense.Api.GameLogic.Items.Models
{
    public class Rockets : IItem
    {
        public string Id { get; set; } = nameof(Rockets);
        public ItemType ItemType { get; set; } = ItemType.Rockets;
        public IItemStats Stats { get; set; } = new MediumCostHighDamageItemStats();

        public IEnumerable<AttackDeclaration> Attack(IArenaGrid opponentsArenaGrid, int attackingGridItemId)
        {
            var affectedGridItemList = ItemHelpers.GetAttackedGridItems(opponentsArenaGrid, attackingGridItemId);
            return affectedGridItemList.Select(x => new AttackDeclaration() { GridItemId = x, Damage = Stats.Damage });
        }
    }
}
