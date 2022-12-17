using TowerDefense.Api.GameLogic.GameState;

namespace TowerDefense.Api.GameLogic.Handlers
{
    public interface ITurnHandler
    {   
        void ResetGame();
        bool TryEndTurn(string playerName);
        void ResetTurn();
    }

    public class TurnHandler : ITurnHandler
    {
        private readonly GameOriginator _game;
        private IGameHandler _gameHandler;

        public TurnHandler()
        {
            _game = GameOriginator.Instance;
        }

        public void SetMediator(IGameHandler gameHandler)
        {
            _gameHandler = gameHandler;
        }

        public bool TryEndTurn(string playerName)
        {
            if (_game.State.PlayersFinishedTurn.ContainsKey(playerName)) return false;
            _game.State.PlayersFinishedTurn.Add(playerName, true);

            if (_game.State.PlayersFinishedTurn.Count != Constants.TowerDefense.MaxNumberOfPlayers) return false;

            _gameHandler.AllPlayersEndedTurn();

            return true;
        }

        public void ResetGame()
        {
            _game.State = new State();
        }

        public void ResetTurn()
        {
            _game.State.PlayersFinishedTurn.Clear();
        }
    }
}
