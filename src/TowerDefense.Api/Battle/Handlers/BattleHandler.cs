using TowerDefense.Api.Contracts;

namespace TowerDefense.Api.Battle.Handlers
{
    public interface IBattleOrchestrator
    {
        void HandleEndTurn(string playerName);
        GetShopItemsResponse GetShopItems();
        GetInventoryItemsResponse GetInventoryItems(string playerName);
        GetGridResponse GetGridItems(string playerName);
        void BuyShopItem(BuyShopItemRequest buyShopItemRequest);
        AddGridItemResponse AddGridItem(AddGridItemRequest addGridItemRequest);
    }

    public class BattleOrchestrator : IBattleOrchestrator
    {
        private readonly GameState _gameState;
        private readonly ITurnHandler _turnHandler;
        private readonly IShop _shop;

        public BattleOrchestrator(ITurnHandler turnHandler, IShop shop)
        {
            _turnHandler = turnHandler;
            _shop = shop;
            _gameState = GameState.Instance;
        }

        public void HandleEndTurn(string playerName)
        {
            _turnHandler.EndTurn(playerName);
        }

        public GetShopItemsResponse GetShopItems()
        {
            return new GetShopItemsResponse { Items = _shop.AllItems };
        }

        public GetInventoryItemsResponse GetInventoryItems(string playerName)
        {
            var player = _gameState.Players.First(x => x.Name == playerName);
            return new GetInventoryItemsResponse { Items = player.Inventory.Items };
        }

        public GetGridResponse GetGridItems(string playerName)
        {
            var player = _gameState.Players.First(x => x.Name == playerName);
            return new GetGridResponse { GridItems = player.ArenaGrid.GridItems };
        }

        public void BuyShopItem(BuyShopItemRequest buyShopItemRequest)
        {
            var player = _gameState.Players.First(x => x.Name == buyShopItemRequest.PlayerName);
            _shop.BuyItem(buyShopItemRequest.ItemId, player);
        }

        public AddGridItemResponse AddGridItem(AddGridItemRequest addGridItemRequest)
        {
            var player = _gameState.Players.First(x => x.Name == addGridItemRequest.PlayerName);

            var inventoryItem = player.Inventory.Items.Find(x => x.Id == addGridItemRequest.InventoryItemId);

            if (inventoryItem == null)
            {
                return new AddGridItemResponse
                {
                    InventoryItems = player.Inventory.Items,
                    GridItems = player.ArenaGrid.GridItems
                };
            }

            player.ArenaGrid.GridItems[addGridItemRequest.GridItemId].ItemType = inventoryItem.ItemType;

            player.Inventory.Items.Remove(inventoryItem);

            return new AddGridItemResponse
            {
                InventoryItems = player.Inventory.Items,
                GridItems = player.ArenaGrid.GridItems
            };
        }


    }
}
