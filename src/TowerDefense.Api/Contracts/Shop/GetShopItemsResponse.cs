using TowerDefense.Api.Models;

namespace TowerDefense.Api.Contracts.Shop
{
    public class GetShopItemsResponse
    {
        public IEnumerable<Item> Items { get; set; }
    }
}
