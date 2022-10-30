﻿using TowerDefense.Api.Battle.Grid;
using TowerDefense.Api.Models;
using TowerDefense.Api.Models.Items;
using TowerDefense.Api.Strategies;
using System.Linq;

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
        public ICollection<string> PowerUps { get; set; }
        protected IItem _item { get; set; }
        protected abstract string _powerUpName { get; }

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
