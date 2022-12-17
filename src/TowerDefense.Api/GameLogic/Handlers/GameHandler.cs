using TowerDefense.Api.Contracts.Turn;
using TowerDefense.Api.GameLogic.GameState;
using TowerDefense.Api.Hubs;
using TowerDefense.Api.Models.Player;

namespace TowerDefense.Api.GameLogic.Handlers
{
    public interface IGameHandler
    {
        Task ResetGame();
        Task FinishGame(IPlayer winnerPlayer);
    }

    class GameHandler : IGameHandler
    {
        private INotificationHub _notificationHub;
        private readonly State _gameState;

        public GameHandler(INotificationHub notificationHub)
        {
            _notificationHub = notificationHub;
            _gameState = GameOriginator.GameState;
        }

        public async Task ResetGame()
        {
            await _notificationHub.ResetGame();
            ClearGameState();
        }

        public async Task FinishGame(IPlayer winnerPlayer)
        {
            await _notificationHub.NotifyGameFinished(winnerPlayer);
            ClearGameState();
        }

        private void ClearGameState()
        {
            GameOriginator.GameState = new State();
        }
    }
}
