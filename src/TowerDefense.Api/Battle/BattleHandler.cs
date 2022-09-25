
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
        public BattleHandler()
        {
            battleShop = new BattleShop(new SimpleItemRepository());
            gameState = GameStateSingleton.Instance;
        }

        public  Player GetPlayer(string playerName)
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

        public GetShopItemsResponse GetShopItems()
        {
            return new GetShopItemsResponse { Items = battleShop.GetItems() };
        }

        public GetInventoryItemsResponse GetInventoryItems(GetInventoryItemsRequest getInventoryItemsRequest)
        {
            var player = gameState.Players.Find(x => x.Name == getInventoryItemsRequest.PlayerName);
            return new GetInventoryItemsResponse { Items = player.Inventory.Items };
        }

        public void BuyShopItem(BuyShopItemRequest buyShopItemRequest)
        {
            var player = gameState.Players.Find(x => x.Name == buyShopItemRequest.PlayerName);
            battleShop.BuyItem(buyShopItemRequest.ItemId, player);
        }

        private Player CreateNewPlayer(AddPlayerRequest addPlayerRequest)
        {
            return new Player { Name = addPlayerRequest.Name, 
                Health = 100, 
                Money = 1000, 
                Inventory = new Inventory()
            };
        }
    }
}
