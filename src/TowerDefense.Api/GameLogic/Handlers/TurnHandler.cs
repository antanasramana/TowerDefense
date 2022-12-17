using TowerDefense.Api.Constants;
using TowerDefense.Api.GameLogic.GameState;
using TowerDefense.Api.GameLogic.Mediator;
using TowerDefense.Api.GameLogic.Memento;
using TowerDefense.Api.GameLogic.Strategies;

namespace TowerDefense.Api.GameLogic.Handlers
{
    public interface ITurnHandler : IComponent
    {   
        void ResetGame();
        bool TryEndTurn(string playerName);
        void ResetTurn();
    }

    public class TurnHandler : ITurnHandler
    {
        private readonly GameOriginator _game;
        private readonly ICaretaker _caretaker;
        private IGameMediator _gameMediator;

        public TurnHandler(ICaretaker caretaker)
        {
            _caretaker = caretaker;
            _game = GameOriginator.Instance;
        }

        public void SetMediator(IGameMediator gameMediator)
        {
            _gameMediator = gameMediator;
        }

        public bool TryEndTurn(string playerName)
        {
            if (_game.State.PlayersFinishedTurn.ContainsKey(playerName)) return false;
            _game.State.PlayersFinishedTurn.Add(playerName, true);

            if (_game.State.PlayersFinishedTurn.Count != Constants.TowerDefense.MaxNumberOfPlayers) return false;

            _gameMediator.Notify(this, MediatorEvent.AllPlayersEndedTurn);

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
