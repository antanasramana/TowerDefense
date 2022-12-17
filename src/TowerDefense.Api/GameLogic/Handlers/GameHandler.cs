using TowerDefense.Api.Contracts.Turn;
using TowerDefense.Api.Hubs;
using TowerDefense.Api.Models.Player;

namespace TowerDefense.Api.GameLogic.Handlers
{
    public interface IGameHandler
    {
        Task PlayerEndedTurn(string playerName);
        Task AllPlayersEndedTurn();
        Task FinishTurn(Dictionary<string, EndTurnResponse> responses);
        Task ResetGame();
        Task FinishGame(IPlayer winnerPlayer);
    }

    class GameHandler : IGameHandler
    {
        private IBattleHandler _battleHandler;
        private ITurnHandler _turnHandler;
        private INotificationHub _notificationHub;

        public GameHandler(IBattleHandler battleHandler, ITurnHandler turnHandler, INotificationHub notificationHub)
        {
            _turnHandler = turnHandler;
            _battleHandler = battleHandler;
            _notificationHub = notificationHub;
        }

        public async Task PlayerEndedTurn(string playerName)
        {
            _turnHandler.TryEndTurn(playerName);
        }

        public async Task AllPlayersEndedTurn()
        {
            _battleHandler.HandleEndTurn();
        }

        public async Task FinishTurn(Dictionary<string, EndTurnResponse> responses)
        {
            await _notificationHub.SendPlayersTurnResult(responses);
            _turnHandler.ResetTurn();
        }

        public async Task ResetGame()
        {
            await _notificationHub.ResetGame();
            _turnHandler.ResetGame();
        }

        public async Task FinishGame(IPlayer winnerPlayer)
        {
            await _notificationHub.NotifyGameFinished(winnerPlayer);
            _turnHandler.ResetGame();
        }
    }
}
