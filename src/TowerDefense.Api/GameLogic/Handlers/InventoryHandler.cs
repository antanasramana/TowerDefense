using TowerDefense.Api.GameLogic.GameState;
using TowerDefense.Api.GameLogic.Items;
using TowerDefense.Api.GameLogic.Player;

namespace TowerDefense.Api.GameLogic.Handlers
{
    public interface IInventoryHandler
    {
        Inventory GetPlayerInventory(string playerName);
    }

    public class InventoryHandler : IInventoryHandler
    {
        private readonly State _gameState;
        public InventoryHandler()
        {
            _gameState = GameOriginator.GameState;
        }
        public Inventory GetPlayerInventory(string playerName)
        {
            var player = _gameState.Players.First(x => x.Name == playerName);
            return player.Inventory;
        }
    }
}
