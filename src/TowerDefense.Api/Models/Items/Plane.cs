﻿using TowerDefense.Api.Battle.Grid;
using TowerDefense.Api.Strategies;

namespace TowerDefense.Api.Models.Items
{
    public class Plane : IItem
    {
        public string Id { get; set; } = nameof(Plane);
        public int Price { get; set; } = 500;
        public ItemType ItemType { get; set; } = ItemType.Plane;
        public int Health { get; set; } = 50;
        public int Damage { get; set; } = 150;
        public IAttackStrategy AttackStrategy { get; set; } = new HorizontalLineAttackStrategy();

        public IEnumerable<AttackResult> Attack(GridItem[] opponentGridItems, int attackingGridItemId)
        {
            var affectedGridItemList = AttackStrategy.AttackedGridItems(opponentGridItems, attackingGridItemId);
            return affectedGridItemList.Select(x => new AttackResult() { GridItemId = x, Damage = Damage });
        }

        public IItem Clone()
        {
            return new Plane
            {
                Id = Guid.NewGuid().ToString()
            };
        }
    }
}
