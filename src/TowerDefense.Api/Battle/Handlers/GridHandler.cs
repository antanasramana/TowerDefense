using TowerDefense.Api.Battle.Grid;

namespace TowerDefense.Api.Battle.Handlers
{
    public interface IGridHandler
    {
        ArenaGrid GetGridItems(string playerName);
        ArenaGrid AddGridItem(string playerName, string inventoryItemId, int gridItemId);
    }

    public class GridHandler : IGridHandler
    {
        private readonly GameState _gameState;
        private readonly IInventoryHandler _inventoryHandler;
        public GridHandler(IInventoryHandler inventoryHandler)
        {
            _gameState = GameState.Instance;
            _inventoryHandler = inventoryHandler;
        }
        public ArenaGrid GetGridItems(string playerName)
        {
            var player = _gameState.Players.First(x => x.Name == playerName);
            return player.ArenaGrid;
        }

        public ArenaGrid AddGridItem(string playerName, string inventoryItemId, int gridItemId)
        {
            var player = _gameState.Players.First(x => x.Name == playerName);

            var inventoryItem = _inventoryHandler.GetItemFromPlayerInventory(playerName, inventoryItemId);
            if (inventoryItem == null) return player.ArenaGrid;

            player.ArenaGrid.GridItems[gridItemId].ItemType = inventoryItem.ItemType;

            _inventoryHandler.RemoveItemFromPlayerInventory(playerName, inventoryItemId);

            return player.ArenaGrid;
        }
    }
}
