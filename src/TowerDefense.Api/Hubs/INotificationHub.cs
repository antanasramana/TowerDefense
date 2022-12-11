using TowerDefense.Api.Contracts.Turn;
using TowerDefense.Api.GameLogic.Mediator;
using TowerDefense.Api.Models.Player;

namespace TowerDefense.Api.Hubs
{
    public interface INotificationHub : IComponent
    {
        Task NotifyGameResult(Dictionary<string, EndTurnResponse> responses);
        Task NotifyGameStart(IPlayer firstPlayer, IPlayer secondPlayer);
        Task SendEndTurnInfo(IPlayer player, EndTurnResponse turnOutcome);
    }
}
