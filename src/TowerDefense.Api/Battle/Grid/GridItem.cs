using TowerDefense.Api.Battle.Observer;
using TowerDefense.Api.Models.Items;

namespace TowerDefense.Api.Battle.Grid
{
    public class GridItem : IAttackSubscriber
    {
        public int Id { get; set; }
        public IItem Item { get; set; }

        public ItemType ItemType => Item.ItemType; 

        public void HandleAttack(int damage)
        {
            bool isDestroyed = Item.Health - damage <= 0;

            if (isDestroyed)
            {
                this.Item = new Blank();
            }
            else
            {
                this.Item.Health -= damage;
            }
        }
    }
}
