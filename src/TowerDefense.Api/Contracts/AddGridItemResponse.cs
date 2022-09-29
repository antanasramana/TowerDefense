using TowerDefense.Api.Battle;
using TowerDefense.Api.Battle.Grid;
using TowerDefense.Api.Models;

namespace TowerDefense.Api.Contracts
{
    public class AddGridItemResponse
    {
        public GridItem[] GridItems { get; set; }
        public List<InventoryItem> InventoryItems { get; set; }
    }
}
