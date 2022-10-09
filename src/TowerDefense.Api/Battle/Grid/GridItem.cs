using TowerDefense.Api.Models.Items;

namespace TowerDefense.Api.Battle.Grid
{
    public class GridItem
    {
        public int Id { get; set; }
        public ItemType ItemType { get; set; }
        public IItem Item { get; set; }

        public void HandleAttack(int damage)
        {
            //If item is not placeholder do stuff below
            //Health of item then equals health minus damage
            //If health equals zero Item then equal blank
        }
    }
}
