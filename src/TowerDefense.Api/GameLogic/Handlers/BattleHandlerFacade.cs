using TowerDefense.Api.Contracts.Turn;
using TowerDefense.Api.GameLogic.Mediator;
using TowerDefense.Api.Hubs;

namespace TowerDefense.Api.GameLogic.Handlers
{
    public interface IBattleHandlerFacade: IComponent
    {
        void HandleEndTurn();
    }

    public class BattleHandlerFacade : IBattleHandlerFacade
    {
        private readonly GameState _gameState;
        private readonly IAttackHandler _attackHandler;
        private IGameMediator _gameMediator;

        public BattleHandlerFacade(IAttackHandler attackHandler)
        {
            _gameState = GameState.Instance;
            _attackHandler = attackHandler;
        }
        public void SetMediator(IGameMediator gameMediator)
        {
            _gameMediator = gameMediator;
        }

        public void HandleEndTurn()
        {
            var player1 = _gameState.Players[0];
            var player2 = _gameState.Players[1];

            var player1ArenaGrid = player1.ArenaGrid;
            var player2ArenaGrid = player2.ArenaGrid;

            // Get all AttackDeclarations

            var player1AttackDeclarations = _attackHandler.HandlePlayerAttacks(player1ArenaGrid, player2ArenaGrid);
            var player2AttackDeclarations = _attackHandler.HandlePlayerAttacks(player2ArenaGrid, player1ArenaGrid);

            // Calculate players earned money 

            player1.Money += _attackHandler.PlayerEarnedMoneyAfterAttack(player1AttackDeclarations);
            player2.Money += _attackHandler.PlayerEarnedMoneyAfterAttack(player2AttackDeclarations);

            // Notify opposing players grid items to receive attack
            var player1AttackResults = player2.Publisher.Notify(player1AttackDeclarations);
            var player2AttackResults = player1.Publisher.Notify(player2AttackDeclarations);

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

            Dictionary<string, EndTurnResponse> responses = new Dictionary<string, EndTurnResponse>();
            responses.Add(player1.Name, player1TurnOutcome);
            responses.Add(player2.Name, player2TurnOutcome);

            _gameMediator.Notify(this, MediatorEvent.TurnResultsCreated, responses);
        }
    }
}
