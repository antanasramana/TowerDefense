using TowerDefense.Api.Battle.Factories;
using TowerDefense.Api.Battle.Observer;
using TowerDefense.Api.Constants;
using TowerDefense.Api.Enums;
using TowerDefense.Api.Hubs;
using TowerDefense.Api.Models.Player;

namespace TowerDefense.Api.Battle.Handlers
{
    public interface IInitialGameSetupHandler
    {
        void SetConnectionIdForPlayer(string playerName, string connectionId);
        IPlayer AddNewPlayerToGame(string playerName, IAbstractLevelFactory abstractLevelFactory);
        void SetArenaGridForPlayer(string playerName, IAbstractLevelFactory abstractLevelFactory);
        void SetShopForPlayer(string playerName, IAbstractLevelFactory abstractLevelFactory);
        void SetLevel(Level level);
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

        public void SetArenaGridForPlayer(string playerName, IAbstractLevelFactory abstractLevelFactory)
        {
            var player = _gameState.Players.First(x => x.Name == playerName);
            var arenaGrid = abstractLevelFactory.CreateArenaGrid();
            player.ArenaGrid = arenaGrid;
        }

        public void SetShopForPlayer(string playerName, IAbstractLevelFactory abstractLevelFactory)
        {
            var player = _gameState.Players.First(x => x.Name == playerName);
            var shop = abstractLevelFactory.CreateShop();
            player.Shop = shop;
        }

        public void SetLevel(Level level)
        {
            _gameState.Level = level;
        }

        public IPlayer AddNewPlayerToGame(string playerName, IAbstractLevelFactory abstractLevelFactory)
        {
            if (_gameState.ActivePlayers == Game.MaxNumberOfPlayers)
            {
                throw new ArgumentException();
            }

            var currentNewPlayerId = _gameState.ActivePlayers;
            var newPlayer = abstractLevelFactory.CreatePlayer(playerName);
            _gameState.Players[currentNewPlayerId] = newPlayer;
            _gameState.GridPublishers[currentNewPlayerId] = new GridPublisher();

            return newPlayer;
        }
    }
}
