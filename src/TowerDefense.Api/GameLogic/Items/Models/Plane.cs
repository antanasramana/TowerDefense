using TowerDefense.Api.GameLogic.Attacks;
using TowerDefense.Api.GameLogic.Grid;

namespace TowerDefense.Api.GameLogic.Items.Models
{
    public class Plane : IItem
    {
        public string Id { get; set; } = nameof(Plane);
        public ItemType ItemType { get; set; } = ItemType.Plane;
        public IItemStats Stats { get; set; } = new SpecialItemStats();

        public IEnumerable<AttackDeclaration> Attack(IArenaGrid opponentsArenaGrid, int attackingGridItemId)
        {
            var affectedGridItemList = ItemHelpers.GetAttackedGridItems(opponentsArenaGrid, attackingGridItemId);
            return affectedGridItemList.Select(x => new AttackDeclaration() { GridItemId = x, Damage = Stats.Damage });
        }
    }
}
