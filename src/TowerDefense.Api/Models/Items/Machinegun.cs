﻿using TowerDefense.Api.Battle.Builders;
using TowerDefense.Api.Battle.Grid;
using TowerDefense.Api.Strategies;

namespace TowerDefense.Api.Models.Items
{
    public class Machinegun : IItem
    {
        public string Id { get; set; } = nameof(Machinegun);
        public int Level { get; set; } = 0;
        public ItemType ItemType { get; set; } = ItemType.Machinegun;
        public IItemStats Stats { get; set; } = new ItemStats(100, 50, 100);
        public ICollection<string> PowerUps { get; set; } = new List<string>();
        public IAttackStrategy AttackStrategy { get; set; } = new LineOfThreeAttackStrategy();

        public IEnumerable<AttackDeclaration> Attack(IArenaGrid opponentsArenaGrid, int attackingGridItemId)
        {
            var affectedGridItemList = AttackStrategy.AttackedGridItems(opponentsArenaGrid, attackingGridItemId);
            return affectedGridItemList.Select(x => new AttackDeclaration() { GridItemId = x, Damage = Stats.Damage, DamageType = DamageType.Projectile });
        }

        public IItem Clone()
        {
            return new Machinegun
            {
                Id = Guid.NewGuid().ToString()
            };
        }

    }
}
