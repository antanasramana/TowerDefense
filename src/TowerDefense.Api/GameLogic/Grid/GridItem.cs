using TowerDefense.Api.GameLogic.Attacks;
using TowerDefense.Api.GameLogic.Items;
using TowerDefense.Api.GameLogic.Items.Models;

namespace TowerDefense.Api.GameLogic.Grid
{
    public class GridItem
    {
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

            IDamage damage = new FireDamage { Size = 1, Intensity = 1, Time = 2 };

            return new AttackResult { GridId = this.Id, Damage = damage };
        }
    }
}
