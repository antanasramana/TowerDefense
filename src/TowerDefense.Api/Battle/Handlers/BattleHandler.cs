using TowerDefense.Api.Battle.Grid;
using TowerDefense.Api.Enums;
using TowerDefense.Api.Hubs;
using TowerDefense.Api.Models;
using TowerDefense.Api.Models.Items;
using TowerDefense.Api.Models.Player;
using TowerDefense.Api.Strategies;
using TowerDefense.Api.Strategies.RocketStrategy;

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
            IRocketsStrategy rocketsStrategy = RocketsStrategyHandler.CreateRocketsStrategy(_gameState.Level);
            IPlayer player1 = _gameState.Players[0];
            IPlayer player2 = _gameState.Players[1];
            IArenaGrid player1ArenaGrid = player1.ArenaGrid;
            IArenaGrid player2ArenaGrid = player2.ArenaGrid;
            List<AttackResult> result = HandlePlayerAttacks(_gameState.Level, player1ArenaGrid, player2ArenaGrid, player2);
            List<AttackResult> player2AttackResult = HandlePlayerAttacks(_gameState.Level, player2ArenaGrid, player1ArenaGrid, player1);
            result.AddRange(player2AttackResult);

            _notificationHub.SendEndTurnInfo(player1, player2);
        }
        private List<AttackResult> HandlePlayerAttacks(Level gameLevel, IArenaGrid playerArenaGrid, IArenaGrid opponentArenaGrid, IPlayer opponent)
        {
            IRocketsStrategy rocketsStrategy = RocketsStrategyHandler.CreateRocketsStrategy(gameLevel);
            List<AttackResult> result = new List<AttackResult>();
            foreach (GridItem gridItem in playerArenaGrid.GridItems)
            {
                if (gridItem.Item is Rockets)
                {
                    Rockets gridRockets = ((Rockets)gridItem.Item);
                    gridRockets.Strategy = rocketsStrategy;
                    List<AttackResult> rocketsAttckResults =
                        ((Rockets)gridItem.Item).Strategy.Attack(opponentArenaGrid.GridItems, opponent, gridRockets.Demage, gridItem.Id);
                    result.AddRange(rocketsAttckResults);
                }
            }
            return result;
        }
    }
}
