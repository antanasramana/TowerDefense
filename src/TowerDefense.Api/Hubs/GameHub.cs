using Microsoft.AspNetCore.SignalR;
using TowerDefense.Api.Battle;

namespace TowerDefense.Api.Hubs
{
    public class GameHub : Hub
    {
        private readonly BattleHandler battleHandler;

        public GameHub ()
        {
            battleHandler = new BattleHandler(this);
        }
        
        public async Task JoinGame( string playerName)
        {       
            await battleHandler.SetConnectionIdForPlayer(playerName, Context.ConnectionId);
        }
    }
}
