namespace TowerDefense.Api.Contracts.Command
{
    public class ExecuteCommandRequest
    {
        public string PlayerName { get; set; }
        public string InventoryItemId { get; set; }
        public string ShopItemId { get; set; }
        public int? GridItemId { get; set; }
    }
}
