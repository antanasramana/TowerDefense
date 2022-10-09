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

        IItem Clone();
    }
}
