using TowerDefense.Api.Models.Items;

namespace TowerDefense.Api.Contracts.Inventory
{
    public class GetInventoryItemsResponse
    {
        public List<IItem> Items { get; set; }
    }
}
