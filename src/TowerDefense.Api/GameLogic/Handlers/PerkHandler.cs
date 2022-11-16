using TowerDefense.Api.GameLogic.PerkStorage;
using TowerDefense.Api.Models;

namespace TowerDefense.Api.GameLogic.Handlers
{
    public interface IPerkHandler
    {
        IPerkStorage GetPerks(string playerName);
        void ApplyPerk(string attackingPlayerName, int perkId);
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

        public void ApplyPerk(string playerName, int perkId)
        {
            // Applying will be done using Visitor and Memento patterns.
            var player = _gameState.Players.First(x => x.Name == playerName);
            var perk = player.PerkStorage.Perks.First(x => x.Id == perkId);
            
            player.PerkStorage.Perks = player.PerkStorage.Perks.Where(x => x.Id != perkId);




        }
    }
}
