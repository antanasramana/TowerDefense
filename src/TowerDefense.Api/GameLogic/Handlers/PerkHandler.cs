using TowerDefense.Api.GameLogic.GameState;
using TowerDefense.Api.GameLogic.Memento;
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
        private readonly ICaretaker _caretaker;
        public PerkHandler(ICaretaker caretaker)
        {
            _game = GameOriginator.Instance;
            _caretaker = caretaker;
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
            _game.State.PerksUsedOnPlayer = new List<(string PlayerName, IPerkDto Perk)>();
        }
    }
}
