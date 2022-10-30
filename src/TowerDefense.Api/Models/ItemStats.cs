namespace TowerDefense.Api.Models
{
    public interface IItemStats
    {
        int Price { get; set; }
        int Health { get; set; }
        int Damage { get; set;  }

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

}
