using TowerDefense.Api.GameLogic.GameState;
using TowerDefense.Api.GameLogic.Player;
using TowerDefense.Api.Hubs;

namespace TowerDefense.Api.GameLogic.Handlers
{
    public interface IGameHandler
    {
        Task ResetGame();
        Task FinishGame(IPlayer winnerPlayer);
    }

    class GameHandler : IGameHandler
    {
        private readonly INotificationHub _notificationHub;

        public GameHandler(INotificationHub notificationHub)
        {
            _notificationHub = notificationHub;
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

        private static void ClearGameState()
        {
            GameOriginator.GameState = new State();
        }
    }
}
