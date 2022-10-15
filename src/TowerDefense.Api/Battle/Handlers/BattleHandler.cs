using TowerDefense.Api.Battle.Grid;
using TowerDefense.Api.Hubs;
using TowerDefense.Api.Models;
using TowerDefense.Api.Models.Player;

namespace TowerDefense.Api.Battle.Handlers
{
    public interface IBattleHandler
    {
        void HandleEndTurn(string playerName);
    }

    public class BattleHandler : IBattleHandler
    {
        private readonly GameState _gameState;
        private readonly ITurnHandler _turnHandler;
        private readonly INotificationHub _notificationHub;

        public BattleHandler(ITurnHandler turnHandler, INotificationHub notificationHub)
        {
            _turnHandler = turnHandler;
            _gameState = GameState.Instance;
            _notificationHub = notificationHub;
        }

        public void HandleEndTurn(string playerName)
        {
            var areTurnsEnded = _turnHandler.TryEndTurn(playerName);
            if (!areTurnsEnded) return;

            //CALCULATE HEALTH AND OTHER STUFF

            var player1ArenaGrid = _gameState.Players[0].ArenaGrid;
            var player2ArenaGrid = _gameState.Players[1].ArenaGrid;
            var player1AttackResult = HandlePlayerAttacks(player1ArenaGrid, player2ArenaGrid);
            var player2AttackResult = HandlePlayerAttacks(player2ArenaGrid, player1ArenaGrid);

            // Observer magic
            _gameState.GridPublishers[0].Notify(player1AttackResult);
            _gameState.GridPublishers[1].Notify(player2AttackResult);

            _notificationHub.SendEndTurnInfo(_gameState.Players[0], _gameState.Players[1]);
        }
        private IEnumerable<AttackDeclaration> HandlePlayerAttacks(IArenaGrid playerArenaGrid, IArenaGrid opponentArenaGrid)
        {
            var result = new List<AttackDeclaration>();
            foreach (GridItem gridItem in playerArenaGrid.GridItems)
            {
                result.AddRange(gridItem.Item.Attack(opponentArenaGrid.GridItems, gridItem.Id));
            }
            return result;
        }
    }
}
