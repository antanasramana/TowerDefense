using TowerDefense.Api.Battle;
using TowerDefense.Api.Models;

namespace TowerDefense.Api.Contracts
{
    public class GetInventoryItemsResponse
    {
        public List<InventoryItem> Items { get; set; }
    }
}
