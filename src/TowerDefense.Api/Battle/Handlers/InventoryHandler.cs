using TowerDefense.Api.Models;

namespace TowerDefense.Api.Battle.Handlers
{
    public interface IInventoryHandler
    {
        Inventory GetPlayerInventory(string playerName);
        InventoryItem GetItemFromPlayerInventory(string playerName, string inventoryItemId);
        public void RemoveItemFromPlayerInventory(string playerName, string inventoryItemId);
    }

    public class InventoryHandler : IInventoryHandler
    {
        private readonly GameState _gameState;
        public InventoryHandler()
        {
            _gameState = GameState.Instance;
        }
        public Inventory GetPlayerInventory(string playerName)
        {
            var player = _gameState.Players.First(x => x.Name == playerName);
            return player.Inventory;
        }

        public InventoryItem GetItemFromPlayerInventory(string playerName, string inventoryItemId)
        {
            var player = _gameState.Players.First(x => x.Name == playerName);

            var inventoryItem = player.Inventory.Items.FirstOrDefault(x => x.Id == inventoryItemId);

            return inventoryItem;
        }

        public void RemoveItemFromPlayerInventory(string playerName, string inventoryItemId)
        {
            var player = _gameState.Players.First(x => x.Name == playerName);

            var inventoryItem = GetItemFromPlayerInventory(playerName, inventoryItemId);

            player.Inventory.Items.Remove(inventoryItem);
        }
    }
}
