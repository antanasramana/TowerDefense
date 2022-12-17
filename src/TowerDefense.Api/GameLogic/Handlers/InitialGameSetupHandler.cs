using TowerDefense.Api.GameLogic.GameState;
using TowerDefense.Api.GameLogic.Grid;
using TowerDefense.Api.GameLogic.PerkStorage;
using TowerDefense.Api.GameLogic.Shop;
using TowerDefense.Api.Hubs;
using TowerDefense.Api.Models.Player;

namespace TowerDefense.Api.GameLogic.Handlers
{
    public interface IInitialGameSetupHandler
    {
        void SetConnectionIdForPlayer(string playerName, string connectionId);
        IPlayer AddNewPlayerToGame(string playerName);
        void SetArenaGridForPlayer(string playerName);
        void SetShopForPlayer(string playerName);
        void SetPerkStorageForPlayer(string playerName);
        Task TryStartGame();
    }

    public class InitialGameSetupHandler : IInitialGameSetupHandler
    {
        private readonly GameOriginator _game;
        private readonly INotificationHub _notificationHub;
        public InitialGameSetupHandler(INotificationHub notificationHub)
        {
            _game = GameOriginator.Instance;
            _notificationHub = notificationHub;
        }

        public void SetConnectionIdForPlayer(string playerName, string connectionId)
        {
            var player = _game.State.Players.First(x => x.Name == playerName);
            player.ConnectionId = connectionId;
        }

        public async Task TryStartGame()
        {
            if (_game.State.ActivePlayers != Constants.TowerDefense.MaxNumberOfPlayers) return;

            await _notificationHub.NotifyGameStart(_game.State.Players[0], _game.State.Players[1]);
        }

        public void SetArenaGridForPlayer(string playerName)
        {
            var player = _game.State.Players.First(x => x.Name == playerName);
            var arenaGrid = new FirstLevelArenaGrid();
            player.ArenaGrid = arenaGrid;
        }

        public void SetShopForPlayer(string playerName)
        {
            var player = _game.State.Players.First(x => x.Name == playerName);
            var shop = new FirstLevelShop();
            player.Shop = shop;
        }

        public void SetPerkStorageForPlayer(string playerName)
        {
            var player = _game.State.Players.First(x => x.Name == playerName);
            var perkStorage = new FirstLevelPerkStorage();
            player.PerkStorage = perkStorage;
        }

        public IPlayer AddNewPlayerToGame(string playerName)
        {
            if (_game.State.ActivePlayers == Constants.TowerDefense.MaxNumberOfPlayers)
            {
                throw new ArgumentException();
            }

            var currentNewPlayerId = _game.State.ActivePlayers;
            var newPlayer = new FirstLevelPlayer();
            _game.State.Players[currentNewPlayerId] = newPlayer;

            return newPlayer;
        }
    }
}
