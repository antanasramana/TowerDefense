using Microsoft.AspNetCore.SignalR;

namespace TowerDefense.Api.Hubs
{
    public class GameHub : Hub
    {
        public async Task HelloServer(string user)
        {
            string connectionId = Context.ConnectionId;
            await Clients.All.SendAsync("HelloClient", $"Hello {user}! ConnectionId-{connectionId}");
        }
    }
}
