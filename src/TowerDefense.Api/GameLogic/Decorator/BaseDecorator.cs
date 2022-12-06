using TowerDefense.Api.GameLogic.Grid;
using TowerDefense.Api.Models;
using TowerDefense.Api.Models.Items;
using TowerDefense.Api.GameLogic.Strategies;

namespace TowerDefense.Api.GameLogic.Decorator
{
    public abstract class BaseDecorator : IItem
    {
        public string Id { get; set; }
        public int Level { get; set; }
        public IItemStats Stats { get; set; }
        public ItemType ItemType { get; set; }
        public BaseAttackStrategy AttackStrategy { get; set; }
        public ICollection<string> PowerUps { get; set; }
        protected IItem _item { get; set; }
        protected abstract string _powerUpName { get; }

        public BaseDecorator(IItem item)
        {
            _item = item;
            Id = item.Id;
            Stats = item.Stats.Clone();
            Level = item.Level + 1;
            AttackStrategy = item.AttackStrategy;
            ItemType = item.ItemType;
            PowerUps = item.PowerUps.ToList();
            PowerUps.Add(_powerUpName);
        }

        public virtual IEnumerable<AttackDeclaration> Attack(IArenaGrid opponentsArenaGrid, int attackingGridItemId)
        {
            return _item.Attack(opponentsArenaGrid, attackingGridItemId);
        }

        public IItem Clone()
        {
            return _item.Clone();
        }
    }
}
