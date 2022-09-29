using Microsoft.AspNetCore.SignalR;
using TowerDefense.Api.Constants;
using TowerDefense.Api.Contracts;
using TowerDefense.Api.Hubs;
using TowerDefense.Api.Models;

namespace TowerDefense.Api.Battle.Handlers
{
    public interface ITurnHandler
    {
        Task EndTurn(string playerName);
        Task StartFirstTurn(Player firstPlayer, Player secondPlayer);
    }

    public class TurnHandler : ITurnHandler
    {
        private readonly GameState _gameState;
        private readonly IHubContext<GameHub> _gameContext;

        public TurnHandler(IHubContext<GameHub> gameContext)
        {
            _gameContext = gameContext;
            _gameState = GameState.Instance;
        }

        public async Task EndTurn(string playerName)
        {
            if (_gameState.PlayersFinishedTurn.ContainsKey(playerName)) return;
            _gameState.PlayersFinishedTurn.Add(playerName, true);

            if (_gameState.PlayersFinishedTurn.Count != Game.MaxNumberOfPlayers) return;
            await SendTurnInfo(_gameState.Players[0], _gameState.Players[1]);
            _gameState.PlayersFinishedTurn.Clear();
        }

        public async Task StartFirstTurn(Player firstPlayer, Player secondPlayer)
        {
            await _gameContext.Clients.Client(firstPlayer.ConnectionId).SendAsync("EnemyInfo", secondPlayer);
            await _gameContext.Clients.Client(secondPlayer.ConnectionId).SendAsync("EnemyInfo", firstPlayer);
        }

        private async Task SendTurnInfo(Player firstPlayer, Player secondPlayer)
        {
            await _gameContext.Clients.Client(firstPlayer.ConnectionId)
                .SendAsync("EndTurn", new EndTurnResponse { GridItems = secondPlayer.ArenaGrid.GridItems } );
            await _gameContext.Clients.Client(secondPlayer.ConnectionId)
                .SendAsync("EndTurn", new EndTurnResponse { GridItems = firstPlayer.ArenaGrid.GridItems } );
        }
    }
}
