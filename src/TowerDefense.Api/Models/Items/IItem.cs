using TowerDefense.Api.Battle.Grid;
using TowerDefense.Api.Models.Player;
using TowerDefense.Api.Strategies;

namespace TowerDefense.Api.Models.Items
{
    public interface IItem
    {
        string Id { get; set; }
        int Price { get; set; }
        int Health { get; set; }
        int Damage { get; set; }
        ItemType ItemType { get; set; }
        IAttackStrategy AttackStrategy { get; set; }
        IEnumerable<AttackDeclaration> Attack(GridItem[] opponentGridItems, int attackingGridItemId);
        IItem Clone();
    }
}
