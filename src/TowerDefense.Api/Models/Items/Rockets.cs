﻿using TowerDefense.Api.Battle.Grid;
using TowerDefense.Api.Strategies;

namespace TowerDefense.Api.Models.Items
{
    public class Rockets : IItem
    {
        public string Id { get; set; } = nameof(Rockets);
        public int Price { get; set; } = 100;

        public ItemType ItemType { get; set; } = ItemType.Rockets;
        public int Health { get; set; } = 25;
        public int Damage { get; set; } = 25;
        public IAttackStrategy AttackStrategy { get; set; } = new FirstInHorizontalLineAttackStrategy();

        public IEnumerable<AttackResult> Attack(GridItem[] opponentGridItems, int attackingGridItemId)
        {
            var affectedGridItemList = AttackStrategy.AttackedGridItems(opponentGridItems, attackingGridItemId);
            return affectedGridItemList.Select(x => new AttackResult() { GridItemId = x, Damage = Damage });
        }

        public IItem Clone()
        {
            return new Rockets
            {
                Id = Guid.NewGuid().ToString()
            };
        }
    }
}