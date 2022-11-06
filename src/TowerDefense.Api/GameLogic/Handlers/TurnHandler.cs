using TowerDefense.Api.Constants;

namespace TowerDefense.Api.GameLogic.Handlers
{
    public interface ITurnHandler
    {
        bool TryEndTurn(string playerName);
    }

    public class TurnHandler : ITurnHandler
    {
        private readonly GameState _gameState;
        private readonly IPlayerHandler _playerHandler;

        public TurnHandler(IPlayerHandler playerHandler)
        {
            _gameState = GameState.Instance;
            _playerHandler = playerHandler;
        }

        public bool TryEndTurn(string playerName)
        {
            var player = _playerHandler.GetPlayer(playerName);

            if (_gameState.PlayersFinishedTurn.ContainsKey(playerName)) return false;
            _gameState.PlayersFinishedTurn.Add(playerName, true);
            player.CommandHistory.Clear();

            if (_gameState.PlayersFinishedTurn.Count != Game.MaxNumberOfPlayers) return false;


            _gameState.PlayersFinishedTurn.Clear();
            return true;
        }
    }
}
