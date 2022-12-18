using TowerDefense.Api.Contracts.Turn;
using TowerDefense.Api.GameLogic.Attacks;
using TowerDefense.Api.GameLogic.GameState;
using TowerDefense.Api.GameLogic.Player;
using TowerDefense.Api.Hubs;

namespace TowerDefense.Api.GameLogic.Handlers
{
    public interface IBattleHandler
    {
        Task HandleEndTurn();
    }

    public class BattleHandler : IBattleHandler
    {
        private readonly State _gameState;
        private readonly IAttackHandler _attackHandler;
        private readonly INotificationHub _notificationHub;
        private readonly IGameHandler _gameHandler;

        public BattleHandler(IAttackHandler attackHandler, IGameHandler gameHandler, INotificationHub notificationHub)
        {
            _gameState = GameOriginator.GameState;
            _attackHandler = attackHandler;
            _gameHandler = gameHandler;
            _notificationHub = notificationHub;
        }

        public async Task HandleEndTurn()
        {
            var player1 = _gameState.Players[0];
            var player2 = _gameState.Players[1];

            var player1ArenaGrid = player1.ArenaGrid;
            var player2ArenaGrid = player2.ArenaGrid;

            // Get all AttackDeclarations

            var player1Attack = _attackHandler.HandlePlayerAttacks(player1ArenaGrid, player2ArenaGrid);
            var player2Attack = _attackHandler.HandlePlayerAttacks(player2ArenaGrid, player1ArenaGrid);

            // Calculate players earned money 

            player1.Money += _attackHandler.PlayerEarnedMoneyAfterAttack(player1Attack.ItemAttackDeclarations);
            player2.Money += _attackHandler.PlayerEarnedMoneyAfterAttack(player2Attack.ItemAttackDeclarations);

            // NotifyPlayerGridItems opposing players grid items to receive attack
            var player1AttackResults = NotifyPlayerGridItems(player2, player1Attack.ItemAttackDeclarations);
            var player2AttackResults = NotifyPlayerGridItems(player1, player2Attack.ItemAttackDeclarations);

            // Calculate damage

            DoDamageToPlayer(player1, player2Attack.DirectAttackDeclarations);
            DoDamageToPlayer(player2, player1Attack.DirectAttackDeclarations);

            
            if (player1.Health <= 0)
            {
                await _gameHandler.FinishGame(player2);
                return;
            }
            if (player2.Health <= 0)
            {
                await _gameHandler.FinishGame(player1);
                return;
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

            var responses = new Dictionary<string, EndTurnResponse>
            {
                { player1.Name, player1TurnOutcome },
                { player2.Name, player2TurnOutcome }
            };

            await _notificationHub.SendPlayersTurnResult(responses);
        }

        private static List<AttackResult> NotifyPlayerGridItems(IPlayer player, IEnumerable<AttackDeclaration> attackDeclarations)
        {
            List<AttackResult> attackResults = new List<AttackResult>();

            foreach (var subscriber in player.ArenaGrid.GridItems)
            {
                foreach (var attackDeclaration in attackDeclarations)
                {
                    if (attackDeclaration == null || attackDeclaration.GridItemId != subscriber.Id) continue;

                    var attackResult = subscriber.HandleAttack(attackDeclaration);
                    attackResults.Add(attackResult);
                }
            }

            return attackResults;
        }

        private static void DoDamageToPlayer(IPlayer player, IEnumerable<AttackDeclaration> attackDeclarations)
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
