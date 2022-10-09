using TowerDefense.Api.Strategies;

namespace TowerDefense.Api.Models.Items
{
    public class Bomb : IItem
    {
        public string Id { get; set; } = nameof(Bomb);
        public int Price { get; set; } = 200;
        
        public ItemType ItemType { get; set; } = ItemType.Bomb;
        public int Health { get; set; } = 0;
        public int Damage { get; set; } = 10;
        public IAttackStrategy AttackStrategy { get; set; } = new FirstInHorizontalLineAttackStrategy();

        public IItem Clone()
        {
            return new Bomb
            {
                Id = Guid.NewGuid().ToString()
            };
        }
    }
}
