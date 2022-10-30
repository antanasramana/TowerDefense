﻿using TowerDefense.Api.Battle.Builders;
using TowerDefense.Api.Battle.Grid;
using TowerDefense.Api.Strategies;

namespace TowerDefense.Api.Models.Items
{
    public class Plane : IItem
    {
        public string Id { get; set; } = nameof(Plane);
        public int Level { get; set; } = 0;
        public ItemType ItemType { get; set; } = ItemType.Plane;
        public IItemStats Stats { get; set; } = new ItemStats(500, 50, 25);
        public ICollection<string> PowerUps { get; set; } = new List<string>();
        public IAttackStrategy AttackStrategy { get; set; } = new HorizontalLineAttackStrategy();

        public IEnumerable<AttackDeclaration> Attack(IArenaGrid opponentsArenaGrid, int attackingGridItemId)
        {
            var affectedGridItemList = AttackStrategy.AttackedGridItems(opponentsArenaGrid, attackingGridItemId);
            return affectedGridItemList.Select(x => new AttackDeclaration() { GridItemId = x, Damage = Stats.Damage, DamageType = DamageType.Fire });
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
