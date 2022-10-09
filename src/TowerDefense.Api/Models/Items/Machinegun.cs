using TowerDefense.Api.Strategies;

namespace TowerDefense.Api.Models.Items
{
    public class Machinegun : IItem
    {
        public string Id { get; set; } = nameof(Machinegun);
        public int Price { get; set; } = 100;
        public ItemType ItemType { get; set; } = ItemType.Machinegun;
        public int Health { get; set; } = 50;
        public int Damage { get; set; } = 50;
        public IAttackStrategy AttackStrategy { get; set; } = new VerticalLineOfThreeAttackStrategy();

        public IItem Clone()
        {
            return new Machinegun
            {
                Id = Guid.NewGuid().ToString()
            };
        }

    }
}
