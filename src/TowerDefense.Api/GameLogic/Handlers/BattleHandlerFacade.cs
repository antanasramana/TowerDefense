﻿using TowerDefense.Api.Contracts.Turn;
using TowerDefense.Api.Hubs;

namespace TowerDefense.Api.GameLogic.Handlers
{
    public interface IBattleHandlerFacade
    {
        void HandleEndTurn(string playerName);
    }

    public class BattleHandlerFacade : IBattleHandlerFacade
    {
        private readonly GameState _gameState;
        private readonly ITurnHandler _turnHandler;
        private readonly INotificationHub _notificationHub;
        private readonly IAttackHandler _attackHandler;

        public BattleHandlerFacade(ITurnHandler turnHandler, INotificationHub notificationHub, IAttackHandler attackHandler)
        {
            _turnHandler = turnHandler;
            _gameState = GameState.Instance;
            _notificationHub = notificationHub;
            _attackHandler = attackHandler;
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

            _notificationHub.SendEndTurnInfo(player1, player1TurnOutcome);
            _notificationHub.SendEndTurnInfo(player2, player2TurnOutcome);
        }
    }
}