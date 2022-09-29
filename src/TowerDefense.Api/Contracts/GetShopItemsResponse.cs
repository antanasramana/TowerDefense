using TowerDefense.Api.Models;

namespace TowerDefense.Api.Contracts
{
    public class GetShopItemsResponse
    {
        public IEnumerable<Item> Items { get; set; }
    }
}
