using TowerDefense.Api.Models;

namespace TowerDefense.Api.Battle.Handlers
{
    public interface IInventoryHandler
    {
        Inventory GetPlayerInventory(string playerName);
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
    }
}
