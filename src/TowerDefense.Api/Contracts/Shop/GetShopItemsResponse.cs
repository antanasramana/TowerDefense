using TowerDefense.Api.Models;
using TowerDefense.Api.Models.Items;

namespace TowerDefense.Api.Contracts.Shop
{
    public class GetShopItemsResponse
    {
        public IEnumerable<IItem> Items { get; set; }
    }
}
