using TowerDefense.Api.Models;

namespace TowerDefense.Api.Battle.Shop
{
    public class FirstLevelShop : IShop
    {
        private readonly List<Item> _items = new()
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
            }
        };

        public IEnumerable<Item> Items => _items;
    }
}
