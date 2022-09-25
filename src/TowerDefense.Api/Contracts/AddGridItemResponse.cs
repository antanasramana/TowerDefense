using TowerDefense.Api.Battle;
using TowerDefense.Api.Battle.Grid;

namespace TowerDefense.Api.Contracts
{
    public class AddGridItemResponse
    {
        public GridItem[] GridItems { get; set; }
        public List<InventoryItem> Items { get; set; }
    }
}
