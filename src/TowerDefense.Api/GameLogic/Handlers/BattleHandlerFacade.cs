using TowerDefense.Api.Contracts.Turn;
using TowerDefense.Api.GameLogic.GameState;
using TowerDefense.Api.GameLogic.Mediator;
using TowerDefense.Api.GameLogic.Memento;
using TowerDefense.Api.Hubs;
using TowerDefense.Api.Models;
using TowerDefense.Api.Models.Perks;

namespace TowerDefense.Api.GameLogic.Handlers
{
    public interface IBattleHandlerFacade: IComponent
    {
        void HandleEndTurn();
    }

    public class BattleHandlerFacade : IBattleHandlerFacade
    {
        private readonly GameOriginator _game;
        private readonly IAttackHandler _attackHandler;
        private IGameMediator _gameMediator;
        private readonly IPerkHandler _perkHandler;
        private readonly ICaretaker _caretaker;
        private readonly IAtomicBombHandler _atomicBombHandler;

        public BattleHandlerFacade(IAttackHandler attackHandler, IPerkHandler perkHandler, ICaretaker caretaker, IAtomicBombHandler atomicBombHandler)
        {
            _game = GameOriginator.Instance;
            _attackHandler = attackHandler;
            _perkHandler = perkHandler;
            _caretaker = caretaker;
            _atomicBombHandler = atomicBombHandler;
        }
        public void SetMediator(IGameMediator gameMediator)
        {
            _gameMediator = gameMediator;
        }

        public void HandleEndTurn()
        {
            var player1 = _game.State.Players[0];
            var player2 = _game.State.Players[1];

            var player1ArenaGrid = player1.ArenaGrid;
            var player2ArenaGrid = player2.ArenaGrid;

            var wasBackInTimeApplied = _perkHandler.ApplyPerks();

            var player1AttackResults = new List<AttackResult>();
            var player2AttackResults = new List<AttackResult>();

            if (!wasBackInTimeApplied)
            {

                // Get all AttackDeclarations

                var player1AttackDeclarations = _attackHandler.HandlePlayerAttacks(player1ArenaGrid, player2ArenaGrid);
                var player2AttackDeclarations = _attackHandler.HandlePlayerAttacks(player2ArenaGrid, player1ArenaGrid);

                // Calculate players earned money 

                player1.Money += _attackHandler.PlayerEarnedMoneyAfterAttack(player1AttackDeclarations);
                player2.Money += _attackHandler.PlayerEarnedMoneyAfterAttack(player2AttackDeclarations);

                // Notify opposing players grid items to receive attack
                player1AttackResults = player2.Publisher.Notify(player1AttackDeclarations);
                player2AttackResults = player1.Publisher.Notify(player2AttackDeclarations);


            }

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

            var snapshot = _game.SaveSnapshot();
            _caretaker.AddSnapshot(snapshot);

            _gameMediator.Notify(this, MediatorEvent.TurnResultsCreated, responses);
            
            //Preperate atomic bombs for next round
            _atomicBombHandler.UpdateState(player1ArenaGrid);
            _atomicBombHandler.UpdateState(player2ArenaGrid);
        }
    }
}
