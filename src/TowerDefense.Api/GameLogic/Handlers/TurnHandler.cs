using TowerDefense.Api.GameLogic.GameState;

namespace TowerDefense.Api.GameLogic.Handlers
{
    public interface ITurnHandler
    {   
        Task TryEndTurn(string playerName);
    }

    public class TurnHandler : ITurnHandler
    {
        private readonly GameOriginator _game;
        private readonly IBattleHandler _battleHandler;

        public TurnHandler(IBattleHandler battleHandler)
        {
            _game = GameOriginator.Instance;
            _battleHandler = battleHandler;
        }

        public async Task TryEndTurn(string playerName)
        {
            if (_game.State.PlayersFinishedTurn.ContainsKey(playerName)) return;
            _game.State.PlayersFinishedTurn.Add(playerName, true);

            if (_game.State.PlayersFinishedTurn.Count != Constants.TowerDefense.MaxNumberOfPlayers) return;

            await _battleHandler.HandleEndTurn();

            _game.State.PlayersFinishedTurn.Clear();
        }
    }
}
