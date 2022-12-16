using Microsoft.AspNetCore.SignalR;
using TowerDefense.Api.Contracts.Turn;
using TowerDefense.Api.GameLogic;
using TowerDefense.Api.GameLogic.Handlers;
using TowerDefense.Api.GameLogic.Mediator;
using TowerDefense.Api.Models.Player;

namespace TowerDefense.Api.Hubs
{
    public class NotificationHub : INotificationHub
    {
        private readonly IHubContext<GameHub> _gameHubContext;
        private IGameMediator _gameMediator;
        private readonly IPlayerHandler _playerHandler;
        public NotificationHub(IHubContext<GameHub> gameHubContext, IPlayerHandler playerHandler)
        {
            _playerHandler = playerHandler;
            _gameHubContext = gameHubContext;
        }
        public void SetMediator(IGameMediator gameMediator)
        {
            _gameMediator = gameMediator;
        }

        public async Task NotifyGameResult(Dictionary<string, EndTurnResponse> responses)
        {
            foreach (var response in responses)
            {
                var player = _playerHandler.GetPlayer(response.Key);
                SendEndTurnInfo(player, response.Value);
            }

            _gameMediator.Notify(this, MediatorEvent.TurnResponsesSent);
        }

        public async Task NotifyGameStart(IPlayer firstPlayer, IPlayer secondPlayer)
        {
            await _gameHubContext.Clients.Client(firstPlayer.ConnectionId).SendAsync("EnemyInfo", secondPlayer);
            await _gameHubContext.Clients.Client(secondPlayer.ConnectionId).SendAsync("EnemyInfo", firstPlayer);
        }

        public async Task SendEndTurnInfo(IPlayer player, EndTurnResponse turnOutcome)
        {
            await _gameHubContext.Clients.Client(player.ConnectionId)
                .SendAsync("EndTurn", turnOutcome);
        }

        public async Task ResetGame()
        {
            var players = _playerHandler.GetPlayers().Where(x => x != null);
            foreach (var player in players)
            {
                await _gameHubContext.Clients.Client(player.ConnectionId).SendAsync("ResetGame");
            }
        }
    }
}
