namespace TowerDefense.Api.Models
{
    public interface IItemStats
    {
        int Price { get; set; }
        int Health { get; set; }
        int Damage { get; set; }

        IItemStats Clone();
    }

    public class DefaultZeroItemStats : IItemStats
    {
        public int Price { get; set; } = 0;
        public int Health { get; set; } = 0;
        public int Damage { get; set; } = 0;

        public IItemStats Clone()
        {
            return new DefaultZeroItemStats { Damage = Damage, Price = Price, Health = Health };
        }
    }
    public class HighCostNoHealthItemStats : IItemStats
    {
        public int Price { get; set; } = 200;
        public int Health { get; set; } = 0;
        public int Damage { get; set; } = 10;

        public IItemStats Clone()
        {
            return new HighCostNoHealthItemStats { Damage = Damage, Price = Price, Health = Health };
        }
    }
    public class HighDamageItemStats : IItemStats
    {
        public int Price { get; set; } = 100;
        public int Health { get; set; } = 50;
        public int Damage { get; set; } = 100;

        public IItemStats Clone()
        {
            return new HighDamageItemStats { Damage = Damage, Price = Price, Health = Health };
        }
    }
    public class SpecialItemStats : IItemStats
    {
        public int Price { get; set; } = 500;
        public int Health { get; set; } = 50;
        public int Damage { get; set; } = 25;

        public IItemStats Clone()
        {
            return new SpecialItemStats { Damage = Damage, Price = Price, Health = Health };
        }
    }
    public class HighHealthItemStats  : IItemStats
    {
        public int Price { get; set; } = 20;
        public int Health { get; set; } = 150;
        public int Damage { get; set; } = 0;

        public IItemStats Clone()
        {
            return new HighHealthItemStats { Damage = Damage, Price = Price, Health = Health };
        }
    }
    public class MediumCostHighDamageItemStats : IItemStats
    {
        public int Price { get; set; } = 100;
        public int Health { get; set; } = 25;
        public int Damage { get; set; } = 60;

        public IItemStats Clone()
        {
            return new MediumCostHighDamageItemStats { Damage = Damage, Price = Price, Health = Health };
        }
    }
    public class BasicDefenseItemStats : IItemStats
    {
        public int Price { get; set; } = 50;
        public int Health { get; set; } = 50;
        public int Damage { get; set; } = 0;

        public IItemStats Clone()
        {
            return new BasicDefenseItemStats { Damage = Damage, Price = Price, Health = Health };
        }
    }
    public class RegularDefaultItemStats : IItemStats
    {
        public int Price { get; set; } = 150;
        public int Health { get; set; } = 10;
        public int Damage { get; set; } = 0;

        public IItemStats Clone()
        {
            return new RegularDefaultItemStats { Damage = Damage, Price = Price, Health = Health };
        }
    }
    public class SmallDefenseItemStats : IItemStats
    {
        public int Price { get; set; } = 0;
        public int Health { get; set; } = 1;
        public int Damage { get; set; } = 0;

        public IItemStats Clone()
        {
            return new BasicDefenseItemStats { Damage = Damage, Price = Price, Health = Health };
        }
    }
    public class AtomicBombItemStats : IItemStats
    {
        public int Price { get; set; } = 0;
        public int Health { get; set; } = 0;
        public int Damage { get; set; } = 500;

        public IItemStats Clone()
        {
            return new BasicDefenseItemStats { Damage = Damage, Price = Price, Health = Health };
        }
    }
    public class InvinsibleDefenseItemStats : IItemStats
    {
        public int Price { get; set; } = 0;
        public int Health { get; set; } = int.MaxValue;
        public int Damage { get; set; } = 0;

        public IItemStats Clone()
        {
            return new DefaultZeroItemStats { Damage = Damage, Price = Price, Health = Health };
        }
    }
}
