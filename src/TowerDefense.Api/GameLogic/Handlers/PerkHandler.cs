using TowerDefense.Api.GameLogic.PerkStorage;
using TowerDefense.Api.Models;

namespace TowerDefense.Api.GameLogic.Handlers
{
    public interface IPerkHandler
    {
        IPerkStorage GetPerks(string playerName);
        void ApplyPerkToOpponent(string attackingPlayerName, int perkId);
    }

    public class PerkHandler : IPerkHandler
    {
        private readonly GameState _gameState;
        public PerkHandler()
        {
            _gameState = GameState.Instance;
        }

        public IPerkStorage GetPerks(string playerName)
        {
            var player = _gameState.Players.First(x => x.Name == playerName);

            return player.PerkStorage;
        }

        public void ApplyPerkToOpponent(string attackingPlayerName, int perkId)
        {
            // Applying will be done using Visitor and Memento patterns.
        }
    }
}
