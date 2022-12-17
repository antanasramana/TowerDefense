using TowerDefense.Api.Enums;
using TowerDefense.Api.GameLogic.GameState;
using TowerDefense.Api.GameLogic.Grid;
using TowerDefense.Api.GameLogic.Memento;
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
        void SetLevel(Level level);
        Task TryStartGame();
    }

    public class InitialGameSetupHandler : IInitialGameSetupHandler
    {
        private readonly GameOriginator _game;
        private readonly INotificationHub _notificationHub;
        private readonly ICaretaker _caretaker;

        public InitialGameSetupHandler(INotificationHub notificationHub, ICaretaker caretaker)
        {
            _game = GameOriginator.Instance;
            _notificationHub = notificationHub;
            _caretaker = caretaker;
        }

        public void SetConnectionIdForPlayer(string playerName, string connectionId)
        {
            var player = _game.State.Players.First(x => x.Name == playerName);
            player.ConnectionId = connectionId;
        }

        public async Task TryStartGame()
        {
            if (_game.State.ActivePlayers != Constants.TowerDefense.MaxNumberOfPlayers) return;

            SaveInitialSnapshot();

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

        public void SetLevel(Level level)
        {
            _game.State.Level = level;
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

        private void SaveInitialSnapshot()
        {
            var snapshot = _game.SaveSnapshot();
            _caretaker.AddSnapshot(snapshot);
        }
    }
}
