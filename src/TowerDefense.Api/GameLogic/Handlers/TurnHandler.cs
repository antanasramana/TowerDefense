using TowerDefense.Api.Constants;
using TowerDefense.Api.GameLogic.GameState;
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
        private readonly GameOriginator _game;
        private IGameMediator _gameMediator;

        public TurnHandler()
        {
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

        public void ResetTurn()
        {
            _game.State.PlayersFinishedTurn.Clear();
        }
    }
}
