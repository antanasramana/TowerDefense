using TowerDefense.Api.Contracts.Turn;
using TowerDefense.Api.GameLogic.Handlers;
using TowerDefense.Api.Hubs;

namespace TowerDefense.Api.GameLogic.Mediator
{
    public interface IGameMediator
    {
        Task Notify(object sender, MediatorEvent _event);
        Task Notify(object sender, MediatorEvent _event, object data);
    }

    class GameMediator : IGameMediator
    {
        private IBattleHandlerFacade _battleHandlerFacade;
        private ITurnHandler _turnHandler;
        private INotificationHub _notificationHub;

        public GameMediator(IBattleHandlerFacade battleHandlerFacade, ITurnHandler turnHandler, INotificationHub notificationHub)
        {
            this._turnHandler = turnHandler;
            this._turnHandler.SetMediator(this);
            this._battleHandlerFacade = battleHandlerFacade;
            this._battleHandlerFacade.SetMediator(this);
            this._notificationHub = notificationHub;
            this._notificationHub.SetMediator(this);
        }

        public async Task Notify(object sender, MediatorEvent _event)
        {
            Notify(sender, _event, null);
        }

        public async Task Notify(object sender, MediatorEvent _event, object data)
        {
            switch (_event)
            {
                case MediatorEvent.PlayerEndedTurn:
                    string playerName = (string)data;
                    _turnHandler.TryEndTurn(playerName);
                    break;
                case MediatorEvent.AllPlayersEndedTurn:
                    _battleHandlerFacade.HandleEndTurn();
                    break;
                case MediatorEvent.TurnResultsCreated:
                    Dictionary<string, EndTurnResponse> responses = (Dictionary<string, EndTurnResponse>)data;
                    await _notificationHub.NotifyGameResult(responses);
                    _turnHandler.ResetTurn();
                    break;
                case MediatorEvent.TurnResponsesSent:
                    _turnHandler.ResetTurn();
                    break;
            }
        }
    }
}
