
using Microsoft.AspNetCore.SignalR;
using TowerDefense.Api.Hubs;
using TowerDefense.Api.Contracts;
using TowerDefense.Api.Battle.Shop;

namespace TowerDefense.Api.Battle
{
    public class BattleHandler
    {
        private const int NumberOfPlayers = 2;

        private readonly GameStateSingleton gameState;
        private readonly TurnHandler turnHandler;
        private readonly BattleShop battleShop;

        public BattleHandler(GameHub gameContext)
        {
            battleShop = new BattleShop(new SimpleItemRepository());
            turnHandler = new TurnHandler(gameContext);
            gameState = GameStateSingleton.Instance;
        }
        public BattleHandler(IHubContext<GameHub> hubContext)
        {
            turnHandler = new TurnHandler(hubContext);
            battleShop = new BattleShop(new SimpleItemRepository());
            gameState = GameStateSingleton.Instance;
        }
        public BattleHandler()
        {
            battleShop = new BattleShop(new SimpleItemRepository());
            gameState = GameStateSingleton.Instance;
        }

        public Player GetPlayer(string playerName)
        {
            return gameState.Players.Find(x => x.Name == playerName);
        }

        public async Task SetConnectionIdForPlayer(string playerName, string connectionId)
        {
            var player = gameState.Players.Find(x => x.Name == playerName);
            player.ConnectionId = connectionId;

            if (gameState.Players.Count == NumberOfPlayers)
            {
                await turnHandler.StartFirstTurn(gameState.Players[0], gameState.Players[1]);
            }
        }
        public void HandleNewPlayer(AddPlayerRequest addPlayerRequest)
        {
            if (gameState.Players.Count == NumberOfPlayers)
            {
                throw new ArgumentException();
            }

            var newPlayer = CreateNewPlayer(addPlayerRequest);
            gameState.Players.Add(newPlayer);
        }

        public void HandleEndTurn(string playerName)
        {
            turnHandler.EndTurn(playerName);
        }


        public GetShopItemsResponse GetShopItems()
        {
            return new GetShopItemsResponse { Items = battleShop.GetItems() };
        }

        public GetInventoryItemsResponse GetInventoryItems(string playerName)
        {
            var player = gameState.Players.Find(x => x.Name == playerName);
            return new GetInventoryItemsResponse { Items = player.Inventory.Items };
        }

        public GetGridResponse GetGridItems(string playerName)
        {
            var player = gameState.Players.Find(x => x.Name == playerName);
            return new GetGridResponse { GridItems = player.ArenaGrid.GridItems };
        }

        public void BuyShopItem(BuyShopItemRequest buyShopItemRequest)
        {
            var player = gameState.Players.Find(x => x.Name == buyShopItemRequest.PlayerName);
            battleShop.BuyItem(buyShopItemRequest.ItemId, player);
        }

        public AddGridItemResponse AddGridItem(AddGridItemRequest addGridItemRequest)
        {
            var player = gameState.Players.Find(x => x.Name == addGridItemRequest.PlayerName);

            var inventoryItem = player.Inventory.Items.Find(x => x.Id == addGridItemRequest.InventoryItemId);

            if (inventoryItem == null)
            {
                return new AddGridItemResponse
                {
                    Items = player.Inventory.Items,
                    GridItems = player.ArenaGrid.GridItems
                };
            }

            player.ArenaGrid.GridItems[addGridItemRequest.GridItemId].ItemType = inventoryItem.ItemType;

            player.Inventory.Items.Remove(inventoryItem);

            return new AddGridItemResponse
            {
                Items = player.Inventory.Items,
                GridItems = player.ArenaGrid.GridItems
            };
        }

        private Player CreateNewPlayer(AddPlayerRequest addPlayerRequest)
        {
            return new Player
            {
                Name = addPlayerRequest.PlayerName,
                Health = 100,
                Money = 1000,
                Inventory = new Inventory(),
                ArenaGrid = new Grid.ArenaGrid()
            };
        }
    }
}
