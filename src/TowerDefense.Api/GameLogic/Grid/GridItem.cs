using TowerDefense.Api.GameLogic.Builders;
using TowerDefense.Api.GameLogic.Items;
using TowerDefense.Api.GameLogic.Items.Models;
using TowerDefense.Api.GameLogic.Observer;
using TowerDefense.Api.Models;

namespace TowerDefense.Api.GameLogic.Grid
{
    public class GridItem : IAttackSubscriber
    {
        private const int SmallDamage = 50;

        public int Id { get; set; }
        public IItem Item { get; set; }

        public ItemType ItemType => Item.ItemType;

        public AttackResult HandleAttack(AttackDeclaration attackDeclaration)
        {
            if (Item.Stats is not DefaultZeroItemStats)
            {
                this.Item.Stats.Health -= attackDeclaration.Damage;
            }

            bool isDestroyed = Item.Stats.Health <= 0;

            if (isDestroyed)
            {

                this.Item = new Blank();

            }

            Damage damage = new FireDamage { Size = 1, Intensity = 1, Time = 2 };

            return new AttackResult { GridId = this.Id, Damage = damage };
        }
    }
}
