using TowerDefense.Api.Constants;
using TowerDefense.Api.Hubs;
using TowerDefense.Api.Models;

namespace TowerDefense.Api.Battle.Handlers
{
    public interface IInitialGameSetupHandler
    {
        void SetConnectionIdForPlayer(string playerName, string connectionId);
        void AddNewPlayerToGame(string playerName);
        Task TryStartGame();
    }

    public class InitialGameSetupHandler : IInitialGameSetupHandler
    {
        private readonly GameState _gameState;
        private readonly INotificationHub _notificationHub;

        public InitialGameSetupHandler(INotificationHub notificationHub)
        {
            _gameState = GameState.Instance;
            _notificationHub = notificationHub;
        }

        public void SetConnectionIdForPlayer(string playerName, string connectionId)
        {
            var player = _gameState.Players.First(x => x.Name == playerName);
            player.ConnectionId = connectionId;
        }

        public async Task TryStartGame()
        {
            if (_gameState.ActivePlayers != Game.MaxNumberOfPlayers) return;

            await _notificationHub.NotifyGameStart(_gameState.Players[0], _gameState.Players[1]);
        }

        public void AddNewPlayerToGame(string playerName)
        {
            if (_gameState.ActivePlayers == Game.MaxNumberOfPlayers)
            {
                throw new ArgumentException();
            }

            var newPlayer = CreateNewPlayer(playerName);
            _gameState.Players[_gameState.ActivePlayers] = newPlayer;
        }

        private static Player CreateNewPlayer(string playerName)
        {
            return new Player
            {
                Name = playerName,
                Health = 100,
                Money = 1000,
                Inventory = new Inventory(),
                ArenaGrid = new Grid.ArenaGrid()
            };
        }
    }
}
