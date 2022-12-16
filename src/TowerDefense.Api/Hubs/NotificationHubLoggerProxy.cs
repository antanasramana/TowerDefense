using Microsoft.AspNetCore.SignalR;
using TowerDefense.Api.Contracts.Turn;
using TowerDefense.Api.GameLogic.Handlers;
using TowerDefense.Api.GameLogic.Mediator;
using TowerDefense.Api.Models.Player;

namespace TowerDefense.Api.Hubs
{
    public class NotificationHubLoggerProxy : INotificationHub
    {
        private NotificationHub _hub;

        public NotificationHubLoggerProxy(IHubContext<GameHub> gameHubContext, IPlayerHandler playerHandler)
        {
            _hub = new NotificationHub(gameHubContext, playerHandler);
        }

        public Task NotifyGameResult(Dictionary<string, EndTurnResponse> responses)
        {    
            foreach (var response in responses)
            {
                Log("Notifying Game result to player: " + response.Key);
            }

            return _hub.NotifyGameResult(responses);
        }

        public Task NotifyGameStart(IPlayer firstPlayer, IPlayer secondPlayer)
        {
            Log("Starting game. Players: " + firstPlayer.Name + " | " + secondPlayer.Name);
            return _hub.NotifyGameStart(firstPlayer, secondPlayer);
        }

        public Task ResetGame()
        {
            Log("BYBYS KIAUŠAI ŠŪDŲ PADAŽE");
            return _hub.ResetGame();
        }

        public Task SendEndTurnInfo(IPlayer player, EndTurnResponse turnOutcome)
        {
            Log("Sending End Turn info. Player: " + player.Name);
            return _hub.SendEndTurnInfo(player, turnOutcome);
        }

        public void SetMediator(IGameMediator mediator)
        {
            Log("Mediator has been set");
            _hub.SetMediator(mediator);
        }

        private void Log(string line)
        {
            string date = DateTime.Now.ToString("HH:mm:ss");

            System.Diagnostics.Debug.WriteLine(date + " [LOG] " + line);
        }
    }
}
