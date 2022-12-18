using TowerDefense.Api.Contracts.Turn;
using TowerDefense.Api.GameLogic.Player;

namespace TowerDefense.Api.Hubs
{
    public interface INotificationHub
    {
        Task SendPlayersTurnResult(Dictionary<string, EndTurnResponse> responses);
        Task NotifyGameStart(IPlayer firstPlayer, IPlayer secondPlayer);
        Task ResetGame();
        Task NotifyGameFinished(IPlayer winner);
    }
}
