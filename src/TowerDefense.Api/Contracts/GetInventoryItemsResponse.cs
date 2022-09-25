using TowerDefense.Api.Battle;
using TowerDefense.Api.Battle.Shop;

namespace TowerDefense.Api.Contracts
{
    public class GetInventoryItemsResponse
    {
        public List<InventoryItem> Items { get; set; }
    }
}
