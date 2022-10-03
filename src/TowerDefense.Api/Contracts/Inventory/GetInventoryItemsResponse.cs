using TowerDefense.Api.Models;

namespace TowerDefense.Api.Contracts.Inventory
{
    public class GetInventoryItemsResponse
    {
        public List<InventoryItem> Items { get; set; }
    }
}
