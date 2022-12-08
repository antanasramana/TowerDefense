using TowerDefense.Api.GameLogic.Factories;
using TowerDefense.Api.Constants;
using TowerDefense.Api.Enums;
using TowerDefense.Api.GameLogic.GameState;
using TowerDefense.Api.GameLogic.Memento;
using TowerDefense.Api.Hubs;
using TowerDefense.Api.Models.Player;

namespace TowerDefense.Api.GameLogic.Handlers
{
    public interface IInitialGameSetupHandler
    {
        void SetConnectionIdForPlayer(string playerName, string connectionId);
        IPlayer AddNewPlayerToGame(string playerName, IAbstractLevelFactory abstractLevelFactory);
        void SetArenaGridForPlayer(string playerName, IAbstractLevelFactory abstractLevelFactory);
        void SetShopForPlayer(string playerName, IAbstractLevelFactory abstractLevelFactory);
        void SetPerkStorageForPlayer(string playerName, IAbstractLevelFactory abstractLevelFactory);
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

        public void SetArenaGridForPlayer(string playerName, IAbstractLevelFactory abstractLevelFactory)
        {
            var player = _game.State.Players.First(x => x.Name == playerName);
            var arenaGrid = abstractLevelFactory.CreateArenaGrid();
            player.ArenaGrid = arenaGrid;
        }

        public void SetShopForPlayer(string playerName, IAbstractLevelFactory abstractLevelFactory)
        {
            var player = _game.State.Players.First(x => x.Name == playerName);
            var shop = abstractLevelFactory.CreateShop();
            player.Shop = shop;
        }

        public void SetPerkStorageForPlayer(string playerName, IAbstractLevelFactory abstractLevelFactory)
        {
            var player = _game.State.Players.First(x => x.Name == playerName);
            var perkStorage = abstractLevelFactory.CreatePerkStorage();
            player.PerkStorage = perkStorage;
        }

        public void SetLevel(Level level)
        {
            _game.State.Level = level;
        }

        public IPlayer AddNewPlayerToGame(string playerName, IAbstractLevelFactory abstractLevelFactory)
        {
            if (_game.State.ActivePlayers == Constants.TowerDefense.MaxNumberOfPlayers)
            {
                throw new ArgumentException();
            }

            var currentNewPlayerId = _game.State.ActivePlayers;
            var newPlayer = abstractLevelFactory.CreatePlayer(playerName);
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
