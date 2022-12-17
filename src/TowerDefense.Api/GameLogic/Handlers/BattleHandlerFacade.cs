using TowerDefense.Api.Contracts.Turn;
using TowerDefense.Api.GameLogic.GameState;
using TowerDefense.Api.GameLogic.Mediator;
using TowerDefense.Api.GameLogic.Memento;
using TowerDefense.Api.Hubs;
using TowerDefense.Api.Models;
using TowerDefense.Api.Models.Perks;
using TowerDefense.Api.Models.Player;

namespace TowerDefense.Api.GameLogic.Handlers
{
    public interface IBattleHandlerFacade : IComponent
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

        public BattleHandlerFacade(IAttackHandler attackHandler, IPerkHandler perkHandler, ICaretaker caretaker)
        {
            _game = GameOriginator.Instance;
            _attackHandler = attackHandler;
            _perkHandler = perkHandler;
            _caretaker = caretaker;
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

                var player1Attack = _attackHandler.HandlePlayerAttacks(player1ArenaGrid, player2ArenaGrid);
                var player2Attack = _attackHandler.HandlePlayerAttacks(player2ArenaGrid, player1ArenaGrid);

                // Calculate players earned money 

                player1.Money += _attackHandler.PlayerEarnedMoneyAfterAttack(player1Attack.ItemAttackDeclarations);
                player2.Money += _attackHandler.PlayerEarnedMoneyAfterAttack(player2Attack.ItemAttackDeclarations);

                // Notify opposing players grid items to receive attack
                player1AttackResults = player2.Publisher.Notify(player1Attack.ItemAttackDeclarations);
                player2AttackResults = player1.Publisher.Notify(player2Attack.ItemAttackDeclarations);

                // Calculate Damage

                DoDamageToPlayer(player1, player2Attack.DirectAttackDeclarations);
                DoDamageToPlayer(player2, player1Attack.DirectAttackDeclarations);

                if (player1.Health <= 0)
                {
                    _gameMediator.Notify(this, MediatorEvent.GameFinished, player2);
                    return;
                }
                else if (player2.Health <= 0)
                {
                    _gameMediator.Notify(this, MediatorEvent.GameFinished, player1);
                    return;
                }

            }

            var player1TurnOutcome = new EndTurnResponse
            {
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
        }

        private void DoDamageToPlayer(IPlayer player, IEnumerable<AttackDeclaration> attackDeclarations)
        {
            foreach (var attack in attackDeclarations)
            {
                player.Armor -= attack.Damage;
                if (player.Armor < 0)
                {
                    var damageToHealth = -player.Armor;
                    player.Armor = 0;
                    player.Health -= damageToHealth;
                }

                if (player.Health < 0)
                {
                    player.Health = 0;
                }
            }
        }
    }
}
