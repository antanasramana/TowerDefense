using Microsoft.AspNetCore.SignalR;
using TowerDefense.Api.Battle;
using TowerDefense.Shared.Models;

namespace TowerDefense.Api.Hubs
{
    public class GameHub : Hub
    {
        private readonly BattleHandler battleHandler;

        public GameHub ()
        {
            // Maybe we can use DI? Questions for "professors"
            this.battleHandler = new BattleHandler ();
        }

        public async Task EndTurn( TurnEnd turnEnd)
        {
            TurnResult result = battleHandler.HandleTurnEnd(turnEnd);

            if (result == null)
            {
                return;
            }

            await Clients.All.SendAsync("TurnResult", result);
        }
    }
}
