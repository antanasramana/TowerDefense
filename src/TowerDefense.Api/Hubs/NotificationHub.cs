using Microsoft.AspNetCore.SignalR;
using TowerDefense.Api.Contracts.Turn;
using TowerDefense.Api.Models.Player;

namespace TowerDefense.Api.Hubs
{
    public interface INotificationHub
    {
        Task NotifyGameStart(IPlayer firstPlayer, IPlayer secondPlayer);
        Task SendEndTurnInfo(IPlayer firstPlayer, IPlayer secondPlayer);
    }

    public class NotificationHub : INotificationHub
    {
        private readonly IHubContext<GameHub> _gameHubContext;
        public NotificationHub(IHubContext<GameHub> gameHubContext)
        {
            _gameHubContext = gameHubContext;
        }

        public async Task NotifyGameStart(IPlayer firstPlayer, IPlayer secondPlayer)
        {
            await _gameHubContext.Clients.Client(firstPlayer.ConnectionId).SendAsync("EnemyInfo", secondPlayer);
            await _gameHubContext.Clients.Client(secondPlayer.ConnectionId).SendAsync("EnemyInfo", firstPlayer);
        }

        public async Task SendEndTurnInfo(IPlayer firstPlayer, IPlayer secondPlayer)
        {
            await _gameHubContext.Clients.Client(firstPlayer.ConnectionId)
                .SendAsync("EndTurn", new EndTurnResponse { GridItems = secondPlayer.ArenaGrid.GridItems });
            await _gameHubContext.Clients.Client(secondPlayer.ConnectionId)
                .SendAsync("EndTurn", new EndTurnResponse { GridItems = firstPlayer.ArenaGrid.GridItems });
        }
    }
}
