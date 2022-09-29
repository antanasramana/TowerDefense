using TowerDefense.Api.Constants;
using TowerDefense.Api.Contracts;
using TowerDefense.Api.Models;

namespace TowerDefense.Api.Battle.Handlers
{
    public interface IInitialGameSetupHandler
    {
        Task SetConnectionIdForPlayer(string playerName, string connectionId);
        void AddNewPlayerToGame(AddNewPlayerRequest addPlayerRequest);
    }

    public class InitialGameSetupHandler : IInitialGameSetupHandler
    {
        private readonly GameState _gameState;
        private readonly ITurnHandler _turnHandler;

        public InitialGameSetupHandler(ITurnHandler turnHandler)
        {
            _gameState = GameState.Instance;
            _turnHandler = turnHandler;
        }
        public async Task SetConnectionIdForPlayer(string playerName, string connectionId)
        {
            var player = _gameState.Players.First(x => x.Name == playerName);
            player.ConnectionId = connectionId;

            if (_gameState.ActivePlayers != Game.MaxNumberOfPlayers) return;

            await _turnHandler.StartFirstTurn(_gameState.Players[0], _gameState.Players[1]);
        }

        public void AddNewPlayerToGame(AddNewPlayerRequest addPlayerRequest)
        {
            if (_gameState.ActivePlayers == Game.MaxNumberOfPlayers)
            {
                throw new ArgumentException();
            }

            var newPlayer = CreateNewPlayer(addPlayerRequest);
            _gameState.Players[_gameState.ActivePlayers] = newPlayer;
        }

        private Player CreateNewPlayer(AddNewPlayerRequest addPlayerRequest)
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
