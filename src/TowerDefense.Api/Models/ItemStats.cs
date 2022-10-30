namespace TowerDefense.Api.Models
{
    public interface IItemStats
    {
        int Price { get; }
        int Health { get; }
        int Damage { get; }

    }

    public class ItemStats : IItemStats 
    {
        public int Price { get; set; }
        public int Health { get; set; }
        public int Damage { get; set; }

        public ItemStats(int price, int health, int damage)
        {
            Price = price;
            Health = health;
            Damage = damage;
        }
    }

    public class DefaulItemStats : IItemStats
    {
        public int Price { get; } = 0;
        public int Health { get; } = 0;
        public int Damage { get; } = 0;
    }

}
