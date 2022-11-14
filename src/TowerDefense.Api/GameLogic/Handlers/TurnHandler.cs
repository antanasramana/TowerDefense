using TowerDefense.Api.Constants;
using TowerDefense.Api.GameLogic.Mediator;

namespace TowerDefense.Api.GameLogic.Handlers
{
    public interface ITurnHandler: IComponent
    {
        bool TryEndTurn(string playerName);
        void ResetTurn();
    }

    public class TurnHandler: ITurnHandler
    {
        private readonly GameState _gameState;
        private IGameMediator _gameMediator;

        public TurnHandler()
        {
            _gameState = GameState.Instance;
        }

        public void SetMediator(IGameMediator gameMediator)
        {
            _gameMediator = gameMediator;
        }

        public bool TryEndTurn(string playerName)
        {
            if (_gameState.PlayersFinishedTurn.ContainsKey(playerName)) return false;
            _gameState.PlayersFinishedTurn.Add(playerName, true);

            if (_gameState.PlayersFinishedTurn.Count != Game.MaxNumberOfPlayers) return false;

            _gameMediator.Notify(this, MediatorEvent.AllPlayersEndedTurn);

            return true;
        }

        public void ResetTurn()
        {
            _gameState.PlayersFinishedTurn.Clear();
        }
    }
}
