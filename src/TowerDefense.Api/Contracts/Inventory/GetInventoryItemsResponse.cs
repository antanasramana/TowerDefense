using TowerDefense.Api.GameLogic.Items;

namespace TowerDefense.Api.Contracts.Inventory
{
    public class GetInventoryItemsResponse
    {
        public List<IItem> Items { get; set; }
    }
}
