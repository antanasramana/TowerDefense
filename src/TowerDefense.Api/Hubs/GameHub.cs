using Microsoft.AspNetCore.SignalR;
using TowerDefense.Api.GameLogic.Handlers;

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
            _initialGameSetup.SetConnectionIdForPlayer(playerName, Context.ConnectionId);
            await _initialGameSetup.TryStartGame();
        }
    }
}
