using TowerDefense.Api.GameLogic.Grid;
using TowerDefense.Api.GameLogic.Strategies;
using TowerDefense.Api.Models;

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
