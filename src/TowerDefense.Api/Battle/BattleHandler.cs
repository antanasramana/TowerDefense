using TowerDefense.Shared.Models;

namespace TowerDefense.Api.Battle
{
    public class BattleHandler
    {
        private const int NumberOfPlayers = 2;

        private readonly GameStateSingleton gameState;

        public BattleHandler ()
        {
            gameState = GameStateSingleton.Instance;
        }

        public TurnResult HandleTurnEnd(TurnEnd  turnEnd)
        {
            gameState.TurnEnds.Add(turnEnd);

            if (gameState.TurnEnds.Count == NumberOfPlayers)
            {
                // TODO: Should be seperate component which takes list of turnEnds and calculates result
                int turnResult = CalculateSum();

                gameState.TurnEnds.Clear();

                return new TurnResult { Sum = turnResult };
            }

            return null;
        }

        private int CalculateSum()
        {
            return gameState.TurnEnds.Select(t => t.Number).Sum();
        }
    }
}
