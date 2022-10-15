﻿using TowerDefense.Api.Battle.Grid;
using TowerDefense.Api.Strategies;

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

        public IEnumerable<AttackResult> Attack(GridItem[] opponentGridItems, int attackingGridItemId)
        {
            var affectedGridItemList = AttackStrategy.AttackedGridItems(opponentGridItems, attackingGridItemId);
            return affectedGridItemList.Select(x => new AttackResult() { GridItemId = x, Damage = Damage });
        }

        public IItem Clone()
        {
            return new Soldier
            {
                Id = Guid.NewGuid().ToString()
            };
        }
    }
}