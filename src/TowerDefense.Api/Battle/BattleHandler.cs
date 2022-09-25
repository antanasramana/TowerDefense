
using Microsoft.AspNetCore.SignalR;
using TowerDefense.Api.Hubs;
using TowerDefense.Api.Player;

namespace TowerDefense.Api.Battle
{
    public class BattleHandler
    {
        private const int NumberOfPlayers = 2;

        private readonly GameStateSingleton gameState;
        private readonly TurnHandler turnHandler;

        public BattleHandler(GameHub gameContext)
        {
            turnHandler = new TurnHandler(gameContext);
            gameState = GameStateSingleton.Instance;
        }
        public BattleHandler()
        {
            gameState = GameStateSingleton.Instance;
        }

        public async Task SetConnectionIdForPlayer(string playerName, string connectionId)
        {
            var player = gameState.Players.Find(x => x.Name == playerName);
            player.ConnectionId = connectionId;

            if (gameState.Players.Count == NumberOfPlayers)
            {
                await turnHandler.SendEnemyInformation(gameState.Players[0], gameState.Players[1]);
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

        private Player CreateNewPlayer(AddPlayerRequest addPlayerRequest)
        {
            return new Player { Name = addPlayerRequest.Name, Health = 100, Money = 1000 };
        }
    }
}
