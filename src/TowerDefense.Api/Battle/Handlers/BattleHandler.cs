using TowerDefense.Api.Battle.Grid;
using TowerDefense.Api.Hubs;
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
            IPlayer player1 = _gameState.Players[0];
            IPlayer player2 = _gameState.Players[1];
            IArenaGrid player1ArenaGrid = player1.ArenaGrid;
            IArenaGrid player2ArenaGrid = player2.ArenaGrid;
            var result = HandlePlayerAttacks(player1ArenaGrid, player2ArenaGrid, player2);
            var player2AttackResult = HandlePlayerAttacks(player2ArenaGrid, player1ArenaGrid, player1);
            result.AddRange(player2AttackResult);

            _notificationHub.SendEndTurnInfo(player1, player2);
        }
        private List<int> HandlePlayerAttacks(IArenaGrid playerArenaGrid, IArenaGrid opponentArenaGrid, IPlayer opponent)
        {
            var result = new List<int>();
            foreach (GridItem gridItem in playerArenaGrid.GridItems)
            {
                result.AddRange(gridItem.Item.AttackStrategy.AttackedGridItems(opponentArenaGrid.GridItems, opponent, gridItem.Item.Damage, gridItem.Id));
            }
            return result;
        }
    }
}
