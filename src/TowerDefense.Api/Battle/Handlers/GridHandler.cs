using Newtonsoft.Json.Linq;
using System;
using TowerDefense.Api.Battle.Grid;
using TowerDefense.Api.Battle.Observer;
using TowerDefense.Api.Models.Items;
using TowerDefense.Api.Models.Player;

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
        private readonly IPublisherHandler _publisherHandler;

        public GridHandler(IInventoryHandler inventoryHandler, IPublisherHandler publisherHandler)
        {
            _gameState = GameState.Instance;
            _inventoryHandler = inventoryHandler;
            _publisherHandler = publisherHandler;
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

            var gridItemSubscriber = player.ArenaGrid.GridItems[gridItemId];

            _publisherHandler.AddSubscriberToPublisher(playerId, gridItemSubscriber);

            _inventoryHandler.RemoveItemFromPlayerInventory(playerName, inventoryItemId);

            return player.ArenaGrid;
        }


    }
}
