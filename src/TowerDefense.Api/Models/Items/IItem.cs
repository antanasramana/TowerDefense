using TowerDefense.Api.GameLogic.Grid;
using TowerDefense.Api.GameLogic.Strategies;

namespace TowerDefense.Api.Models.Items
{
    public interface IItem
    {
        string Id { get; set; }
        int Level { get; set; }
        IItemStats Stats { get; set; }
        ItemType ItemType { get; set; }
        IAttackStrategy AttackStrategy { get; set; }
        IEnumerable<AttackDeclaration> Attack(IArenaGrid opponentsArenaGrid, int attackingGridItemId);

        /// <summary>
        /// Just cosmetic property to show that we add decorators
        /// </summary>
        ICollection<string> PowerUps { get; set; }
        IItem Clone();
    }
}
