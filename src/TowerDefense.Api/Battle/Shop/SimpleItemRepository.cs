namespace TowerDefense.Api.Battle.Shop
{
    public class SimpleItemRepository : IItemRepository
    {
        private readonly List<Item> items = new List<Item>
        {
            new Item
            {
                Id="Rockets",
                ItemType=ItemType.Rockets,
                Price=50,
            },
             new Item
            {
                Id="Shield",
                ItemType=ItemType.Shield,
                Price=20,
            },
        };

        public List<Item> GetItems()
        {
            return items;
        }
    }
}
