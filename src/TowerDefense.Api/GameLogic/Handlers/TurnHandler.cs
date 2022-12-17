using TowerDefense.Api.GameLogic.GameState;

namespace TowerDefense.Api.GameLogic.Handlers
{
    public interface ITurnHandler
    {   
        Task TryEndTurn(string playerName);
    }

    public class TurnHandler : ITurnHandler
    {
        private readonly State _gameState;
        private readonly IBattleHandler _battleHandler;

        public TurnHandler(IBattleHandler battleHandler)
        {
            _gameState = GameOriginator.GameState;
            _battleHandler = battleHandler;
        }

        public async Task TryEndTurn(string playerName)
        {
            if (_gameState.PlayersFinishedTurn.ContainsKey(playerName)) return;
            _gameState.PlayersFinishedTurn.Add(playerName, true);

            if (_gameState.PlayersFinishedTurn.Count != Constants.TowerDefense.MaxNumberOfPlayers) return;

            await _battleHandler.HandleEndTurn();

            _gameState.PlayersFinishedTurn.Clear();
        }
    }
}
