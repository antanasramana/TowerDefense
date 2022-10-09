using TowerDefense.Api.Battle.Observer;
using TowerDefense.Api.Models.Items;

namespace TowerDefense.Api.Battle.Grid
{
    public class GridItem : IAttackSubscriber
    {
        public int Id { get; set; }
        public ItemType ItemType { get; set; }
        public IItem Item { get; set; }

        public void HandleAttack(int damage)
        {
            if(Item.Health - damage <= 0)
            {
                this.ItemType = ItemType.Blank;
                this.Item.ItemType = ItemType.Blank;
                System.Diagnostics.Debug.WriteLine("GridItem destroyed");
            } 
            else
            {
                this.Item.Health = Item.Health - damage;
                System.Diagnostics.Debug.WriteLine("Removed Damage");
            }
        }
    }
}
