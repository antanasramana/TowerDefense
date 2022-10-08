using TowerDefense.Api.Constants;

namespace TowerDefense.Api.Battle.Handlers
{
    public interface ITurnHandler
    {
        bool TryEndTurn(string playerName);
    }

    public class TurnHandler : ITurnHandler
    {
        private readonly GameState _gameState;

        public TurnHandler()
        {
            _gameState = GameState.Instance;
        }

        public bool TryEndTurn(string playerName)
        {
            if (_gameState.PlayersFinishedTurn.ContainsKey(playerName)) return false;
            _gameState.PlayersFinishedTurn.Add(playerName, true);

            if (_gameState.PlayersFinishedTurn.Count != Game.MaxNumberOfPlayers) return false;


            _gameState.PlayersFinishedTurn.Clear();
            return true;
        }
    }
}
