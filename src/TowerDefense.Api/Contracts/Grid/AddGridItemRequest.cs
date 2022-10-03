namespace TowerDefense.Api.Contracts.Grid
{
    public class AddGridItemRequest
    {
        public string PlayerName { get; set; }
        public string InventoryItemId { get; set; }
        public int GridItemId { get; set; }
    }
}
