﻿using TowerDefense.Api.Strategies;

namespace TowerDefense.Api.Models.Items
{
    public class Soldier : IItem
    {
        public string Id { get; set; } = nameof(Soldier);
        public int Price { get; set; } = 150;
        public ItemType ItemType { get; set; } = ItemType.Soldier;
        public int Health { get; set; } = 10;
        public int Damage { get; set; } = 25;
        public IAttackStrategy AttackStrategy { get; set; } = new FirstInHorizontalLineAttackStrategy();

        public IItem Clone()
        {
            return new Soldier
            {
                Id = Guid.NewGuid().ToString()
            };
        }
    }
}
