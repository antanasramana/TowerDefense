using TowerDefense.Api.Hubs;

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

            _notificationHub.SendEndTurnInfo(_gameState.Players[0], _gameState.Players[1]);
        }
    }
}
