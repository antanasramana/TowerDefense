using TowerDefense.Api.GameLogic.GameState;
using TowerDefense.Api.Models;
using TowerDefense.Api.Models.Items;

namespace TowerDefense.Api.GameLogic.Handlers
{
    public interface IInventoryHandler
    {
        Inventory GetPlayerInventory(string playerName);
        IItem GetItemFromPlayerInventory(string playerName, string inventoryItemId);
        public void RemoveItemFromPlayerInventory(string playerName, string inventoryItemId);
    }

    public class InventoryHandler : IInventoryHandler
    {
        private readonly GameOriginator _game;
        public InventoryHandler()
        {
            _game = GameOriginator.Instance;
        }
        public Inventory GetPlayerInventory(string playerName)
        {
            var player = _game.State.Players.First(x => x.Name == playerName);
            return player.Inventory;
        }

        public IItem GetItemFromPlayerInventory(string playerName, string inventoryItemId)
        {
            var player = _game.State.Players.First(x => x.Name == playerName);

            var inventoryItem = player.Inventory.Items.FirstOrDefault(x => x.Id == inventoryItemId);

            return inventoryItem;
        }

        public void RemoveItemFromPlayerInventory(string playerName, string inventoryItemId)
        {
            var player = _game.State.Players.First(x => x.Name == playerName);

            var inventoryItem = GetItemFromPlayerInventory(playerName, inventoryItemId);

            player.Inventory.Items.Remove(inventoryItem);
        }
    }
}
