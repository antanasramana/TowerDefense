using TowerDefense.Api.Battle.Grid;
using TowerDefense.Api.Models;
using TowerDefense.Api.Models.Items;
using TowerDefense.Api.Strategies;

namespace TowerDefense.Api.Decorator
{
    public abstract class BaseDecorator : IItem
    {
        public string Id { get; set; }
        public int Price { get; set; }
        public int Level { get; set; }
        public int Health { get; set; }
        public int Damage { get; set; }
        public ItemType ItemType { get; set; }
        public IAttackStrategy AttackStrategy { get; set; }

        protected IItem _item { get; set; }

        public BaseDecorator(IItem item)
        {
            _item = item;
            Id = item.Id;
            Price = item.Price;
            Level = item.Level + 1;
            Health = item.Health;
            Damage = item.Damage;
            AttackStrategy = item.AttackStrategy;
            ItemType = item.ItemType;
        }

        public virtual IEnumerable<AttackDeclaration> Attack(AttackInformation attackInformation)
        {
            return _item.Attack(attackInformation);
        }

        public IItem Clone()
        {
            return _item.Clone();
        }
    }
}
