using Microsoft.AspNetCore.SignalR;
using TowerDefense.Api.Contracts;
using TowerDefense.Api.Hubs;

namespace TowerDefense.Api.Battle
{
    public class TurnHandler
    {
        const int MaxNumberOfplayer = 2;
        static Dictionary<string, bool> PlayersFinished = new Dictionary<string, bool>();
        private readonly GameStateSingleton gameState;

        private readonly GameHub gameContext;

        private readonly IHubContext<GameHub> gameContext2;

        public TurnHandler(GameHub gameContext)
        {
            this.gameContext = gameContext;
            this.gameState = GameStateSingleton.Instance;
        }
        public TurnHandler(IHubContext<GameHub> gameContext)
        {
            this.gameContext2 = gameContext;
            this.gameState = GameStateSingleton.Instance;
        }

        public async Task EndTurn(string playerName)
        {
            if (!PlayersFinished.ContainsKey(playerName))
            {
                PlayersFinished.Add(playerName, true);
            }

            if (PlayersFinished.Count == MaxNumberOfplayer)
            {
                await SendTurnInfo(gameState.Players[0], gameState.Players[1]);
                PlayersFinished.Clear();
            }
        }


        private async Task SendTurnInfo(Player player1, Player player2)
        {
            await this.gameContext2.Clients.Client(player1.ConnectionId).SendAsync("EndTurn", new EndTurnResponse { GridItems = player2.ArenaGrid.GridItems } );
            await this.gameContext2.Clients.Client(player2.ConnectionId).SendAsync("EndTurn", new EndTurnResponse { GridItems = player1.ArenaGrid.GridItems } );
        }

        public async Task StartFirstTurn(Player player1, Player player2)
        {
            await this.gameContext.Clients.Client(player1.ConnectionId).SendAsync("EnemyInfo", player2);
            await this.gameContext.Clients.Client(player2.ConnectionId).SendAsync("EnemyInfo", player1);
        }
        /*
        public async Task EndTurn(Player player1, Player player2)
        {
            await this.gameContext.Clients.Client(player1.ConnectionId).SendAsync("EndTurn", player2);
            await this.gameContext.Clients.Client(player2.ConnectionId).SendAsync("EndTurn", player1);
        }*/
    }
}
