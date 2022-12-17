using TowerDefense.Api.GameLogic.GameState;
using TowerDefense.Api.GameLogic.PerkStorage;
using TowerDefense.Api.Models.Perks;

namespace TowerDefense.Api.GameLogic.Handlers
{
    public interface IPerkHandler
    {
        IPerkStorage GetPerks(string playerName);
        void UsePerk(string perkUsingPlayerName, int perkId);
        bool ApplyPerks();
    }

    public class PerkHandler : IPerkHandler
    {
        private readonly GameOriginator _game;
        public PerkHandler()
        {
            _game = GameOriginator.Instance;
        }

        public IPerkStorage GetPerks(string playerName)
        {
            var player = _game.State.Players.First(x => x.Name == playerName);

            return player.PerkStorage;
        }

        public void UsePerk(string perkUsingPlayerName, int perkId)
        {
            var player = _game.State.Players.First(x => x.Name == perkUsingPlayerName);
            var enemyPlayer = _game.State.Players.First(x => x.Name != perkUsingPlayerName);

            var perks = player.PerkStorage.Perks;
        }

        public bool ApplyPerks()
        {
            return false;
        }

        private void RemoveUsedPerks()
        {
            _game.State.PerksUsedOnPlayer = new List<(string PlayerName, IPerk Perk)>();
        }
    }
}
