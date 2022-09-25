using Microsoft.AspNetCore.SignalR;
using TowerDefense.Api.Hubs;

namespace TowerDefense.Api.Battle
{
    public class TurnHandler
    {
        private readonly GameHub gameContext;

        public TurnHandler(GameHub gameContext)
        {
            this.gameContext = gameContext;
        }

        public async Task SendEnemyInformation(Player player1, Player player2)
        {
            await this.gameContext.Clients.Client(player1.ConnectionId).SendAsync("EnemyInfo", player2);
            await this.gameContext.Clients.Client(player2.ConnectionId).SendAsync("EnemyInfo", player1);
        }
    }
}
