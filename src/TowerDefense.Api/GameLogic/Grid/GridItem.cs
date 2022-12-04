using TowerDefense.Api.GameLogic.Builders;
using TowerDefense.Api.GameLogic.Observer;
using TowerDefense.Api.Models;
using TowerDefense.Api.Models.Items;

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
                if(this.Item is AtomicBomb)
                {
                    if (!((AtomicBomb)this.Item).PreviousState())
                    {
                        this.Item = new Blank();
                    }
                }
                else
                {
                    this.Item = new Blank();
                }
            }

            IDamageBuilder damageBuilder = null;

            switch (attackDeclaration.DamageType)
            {
                case DamageType.Fire:
                    damageBuilder = new FireDamageBuilder();
                    break;
                case DamageType.Projectile:
                    damageBuilder = new ProjectileDamageBuilder();
                    break;
            }

            DamageBuilderDirector director = new DamageBuilderDirector();

            if (attackDeclaration.Damage <= SmallDamage)
            {
                director.MakeSmallDamage(damageBuilder);
            }
            else
            {
                director.MakeBigDamage(damageBuilder);
            }

            Damage damage = damageBuilder.GetResult();

            return new AttackResult { GridId = this.Id, Damage = damage };
        }
    }
}
