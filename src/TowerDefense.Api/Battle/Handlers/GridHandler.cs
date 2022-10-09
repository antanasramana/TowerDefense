using Newtonsoft.Json.Linq;
using System;
using TowerDefense.Api.Battle.Grid;
using TowerDefense.Api.Models.Items;

namespace TowerDefense.Api.Battle.Handlers
{
    public interface IGridHandler
    {
        IArenaGrid GetGridItems(string playerName);
        IArenaGrid AddGridItem(string playerName, string inventoryItemId, int gridItemId);
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
        public IArenaGrid GetGridItems(string playerName)
        {
            var player = _gameState.Players.First(x => x.Name == playerName);
            return player.ArenaGrid;
        }

        public IArenaGrid AddGridItem(string playerName, string inventoryItemId, int gridItemId)
        {
            var player = _gameState.Players.First(x => x.Name == playerName);
            
            int playerId = Array.IndexOf(_gameState.Players, player);

            var inventoryItem = _inventoryHandler.GetItemFromPlayerInventory(playerName, inventoryItemId);
            if (inventoryItem == null) return player.ArenaGrid;

            player.ArenaGrid.GridItems[gridItemId].ItemType = inventoryItem.ItemType;
            player.ArenaGrid.GridItems[gridItemId].Item = inventoryItem;

            bool isItemValid = (player.ArenaGrid.GridItems[gridItemId].ItemType != ItemType.Blank ||
                                player.ArenaGrid.GridItems[gridItemId].ItemType != ItemType.Placeholder);

            if (isItemValid)
            {
                switch (playerId)
                {
                    case 0:
                        _gameState.gridObservers[1].Attach(player.ArenaGrid.GridItems[gridItemId]);
                        break;
                    
                    case 1:
                        _gameState.gridObservers[0].Attach(player.ArenaGrid.GridItems[gridItemId]);
                        break;
                }
            }

            _inventoryHandler.RemoveItemFromPlayerInventory(playerName, inventoryItemId);

            return player.ArenaGrid;
        }
    }
}
