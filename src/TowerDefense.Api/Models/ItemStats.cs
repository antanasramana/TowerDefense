namespace TowerDefense.Api.Models
{
    public interface IItemStats
    {
        int Price { get; set; }
        int Health { get; set; }
        int Damage { get; set; }

    }

    public class DefaultZeroItemStats : IItemStats
    {
        public int Price { get; set; } = 0;
        public int Health { get; set; } = 0;
        public int Damage { get; set; } = 0;
    }
    public class HighCostNoHealthItemStats : IItemStats
    {
        public int Price { get; set; } = 200;
        public int Health { get; set; } = 0;
        public int Damage { get; set; } = 10;
    }
    public class HighDamageItemStats : IItemStats
    {
        public int Price { get; set; } = 100;
        public int Health { get; set; } = 50;
        public int Damage { get; set; } = 100;
    }
    public class SpecialItemStats : IItemStats
    {
        public int Price { get; set; } = 500;
        public int Health { get; set; } = 50;
        public int Damage { get; set; } = 25;
    }
    public class HighHealthItemStats  : IItemStats
    {
        public int Price { get; set; } = 20;
        public int Health { get; set; } = 150;
        public int Damage { get; set; } = 0;
    }
    public class MediumCostHighDamageItemStats : IItemStats
    {
        public int Price { get; set; } = 100;
        public int Health { get; set; } = 25;
        public int Damage { get; set; } = 60;
    }
    public class BasicDefenseItemStats : IItemStats
    {
        public int Price { get; set; } = 50;
        public int Health { get; set; } = 50;
        public int Damage { get; set; } = 0;
    }
    public class RegularDefaultItemStats : IItemStats
    {
        public int Price { get; set; } = 150;
        public int Health { get; set; } = 10;
        public int Damage { get; set; } = 0;
    }

    /* Legacy ItemStats Builder
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
    } */

}
