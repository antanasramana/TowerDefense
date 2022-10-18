using TowerDefense.Api.Battle.Grid;
using TowerDefense.Api.Contracts.Turn;
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

            var player1 = _gameState.Players[0];
            var player2 = _gameState.Players[1];

            var player1ArenaGrid = player1.ArenaGrid;
            var player2ArenaGrid = player2.ArenaGrid;

            // Get all AttackDeclarations

            var player1AttackDeclarations = HandlePlayerAttacks(player1ArenaGrid, player2ArenaGrid);
            var player2AttackDeclarations = HandlePlayerAttacks(player2ArenaGrid, player1ArenaGrid);

            // Notify opposing players grid items to receive attack
            var player1AttackResults = player1.Publisher.Notify(player1AttackDeclarations);
            var player2AttackResults = player2.Publisher.Notify(player2AttackDeclarations);

            var player1TurnOutcome = new EndTurnResponse { 
                GridItems = player2ArenaGrid.GridItems, 
                PlayerAttackResults = player2AttackResults, 
                EnemyAttackResults = player1AttackResults
            };
            var player2TurnOutcome = new EndTurnResponse
            {
                GridItems = player1ArenaGrid.GridItems,
                PlayerAttackResults = player1AttackResults,
                EnemyAttackResults = player2AttackResults
            };

            _notificationHub.SendEndTurnInfo(player1, player1TurnOutcome);
            _notificationHub.SendEndTurnInfo(player2, player2TurnOutcome);
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
