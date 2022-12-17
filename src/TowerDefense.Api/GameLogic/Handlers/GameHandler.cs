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
        private readonly GameOriginator _game;

        public GameHandler(INotificationHub notificationHub)
        {
            _notificationHub = notificationHub;
            _game = GameOriginator.Instance;
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
            _game.State = new State();
        }
    }
}
