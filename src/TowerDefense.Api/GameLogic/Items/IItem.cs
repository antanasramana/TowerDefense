using TowerDefense.Api.GameLogic.Attacks;
using TowerDefense.Api.GameLogic.Grid;

namespace TowerDefense.Api.GameLogic.Items
{
    public interface IItem
    {
        string Id { get; set; }
        IItemStats Stats { get; set; }
        ItemType ItemType { get; set; }
        IEnumerable<AttackDeclaration> Attack(IArenaGrid opponentsArenaGrid, int attackingGridItemId);
    }
}
