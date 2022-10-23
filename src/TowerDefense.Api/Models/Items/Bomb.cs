﻿using TowerDefense.Api.Adapter;
using TowerDefense.Api.Battle.Grid;
using TowerDefense.Api.Strategies;

namespace TowerDefense.Api.Models.Items
{
    public class Bomb : IItem
    {
        public string Id { get; set; } = nameof(Bomb);
        public int Price { get; set; } = 200;
        public int Level { get; set; } = 0;
        public ItemType ItemType { get; set; } = ItemType.Bomb;
        public int Health { get; set; } = 0;
        public int Damage { get; set; } = 10;
        public IAttackStrategy AttackStrategy { get; set; } = new FirstInHorizontalLineAttackStrategy();

        public IEnumerable<AttackDeclaration> Attack(GridItem[] opponentGridItems, int attackingGridItemId)
        {
            var attackAdapter = new AttackInformationAdapter(AttackStrategy);
            var affectedGridItemList = attackAdapter.AttackedGridItems(opponentGridItems, attackingGridItemId);
            return affectedGridItemList.Select(x => new AttackDeclaration() { GridItemId = x, Damage = Damage });
        }

        public IItem Clone()
        {
            return new Bomb
            {
                Id = Guid.NewGuid().ToString()
            };
        }
    }
}
