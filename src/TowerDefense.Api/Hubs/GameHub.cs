using Microsoft.AspNetCore.SignalR;
using TowerDefense.Api.Battle;
using TowerDefense.Api.Battle.Handlers;

namespace TowerDefense.Api.Hubs
{
    public class GameHub : Hub
    {
        private readonly IInitialGameSetupHandler _initialGameSetup;

        public GameHub(IInitialGameSetupHandler initialGameSetup)
        {
            _initialGameSetup = initialGameSetup;
        }
        
        public async Task JoinGame(string playerName)
        {       
            await _initialGameSetup.SetConnectionIdForPlayer(playerName, Context.ConnectionId);
        }
    }
}
