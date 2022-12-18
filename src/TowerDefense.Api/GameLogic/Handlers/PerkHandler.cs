using TowerDefense.Api.GameLogic.GameState;
using TowerDefense.Api.GameLogic.PerkStorage;
using TowerDefense.Api.Models.Perks;

namespace TowerDefense.Api.GameLogic.Handlers
{
    public interface IPerkHandler
    {
        IPerkStorage GetPerks(string playerName);
        void UsePerk(string perkUsingPlayerName, int perkId);
    }

    public class PerkHandler : IPerkHandler
    {
        private readonly State _gameState;
        public PerkHandler()
        {
            _gameState = GameOriginator.GameState;
        }

        public IPerkStorage GetPerks(string playerName)
        {
            var player = _gameState.Players.First(x => x.Name == playerName);

            return player.PerkStorage;
        }

        public void UsePerk(string perkUsingPlayerName, int perkId)
        {
            var player = _gameState.Players.First(x => x.Name == perkUsingPlayerName);
            var enemyPlayer = _gameState.Players.First(x => x.Name != perkUsingPlayerName);

            var perk = player.PerkStorage.Perks.Where(x => x.Id == perkId).FirstOrDefault();

            if (perk == null)
            {
                return;
            }

            if (perk.Type == PerkType.CutInHalf)
            {
                enemyPlayer.Money /= 2;
                player.PerkStorage.Perks = player.PerkStorage.Perks.Where(x => x.Id != perkId);
            }
        }
    }
}
