using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
using TowerDefense.Api.GameLogic.GameState;
using TowerDefense.Api.GameLogic.Memento;
using TowerDefense.Api.GameLogic.PerkStorage;
using TowerDefense.Api.GameLogic.Visitor;
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
        private readonly Game _game;
        private readonly ICaretaker _caretaker;
        public PerkHandler(ICaretaker caretaker)
        {
            _game = Game.Instance;
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

            var usedPerk = perks.First(x => x.Id == perkId);
            player.PerkStorage.Perks = perks.Where(x => x.Id != usedPerk.Id);

            if (usedPerk is IPersonalPerk)
            {
                _game.State.PerksUsedOnPlayer.Add((player.Name, usedPerk));
                return;
            }
            _game.State.PerksUsedOnPlayer.Add((enemyPlayer.Name, usedPerk));
        }

        public bool ApplyPerks()
        {
            foreach (var playerPerkPair in _game.State.PerksUsedOnPlayer)
            {
                if (playerPerkPair.Perk.Type == PerkType.BackInTime)
                {
                    var snapshot = _caretaker.GoBackToPreviousState();
                    snapshot.Restore();

                    var playerThatUsedPerk = _game.State.Players.First(x => x.Name == playerPerkPair.PlayerName);
                    playerThatUsedPerk.PerkStorage.Perks =
                        playerThatUsedPerk.PerkStorage.Perks.Where(x => x.Type != PerkType.BackInTime);

                    RemoveUsedPerks();
                    return true;
                }

                IVisitor visitor = playerPerkPair.Perk.Type switch
                {
                    PerkType.CutInHalf => new CutInHalfPerkVisitor(),
                    PerkType.Restore => new RestorePerkVisitor(),
                    PerkType.RemoveEverything => new RemoveEverythingPerkVisitor(),
                    PerkType.BackInTime => throw new ArgumentException(),
                    _ => throw new ArgumentOutOfRangeException()
                };

                var playerToVisit = _game.State.Players.First(x => x.Name == playerPerkPair.PlayerName);
                var inventoryToVisit = playerToVisit.Inventory;
                var gridToVisit = playerToVisit.ArenaGrid;

                playerToVisit.Accept(visitor);
                inventoryToVisit.Accept(visitor);
                gridToVisit.Accept(visitor);
            }

            RemoveUsedPerks();
            return false;
        }

        private void RemoveUsedPerks()
        {
            _game.State.PerksUsedOnPlayer = new List<(string PlayerName, IPerkDto Perk)>();
        }
    }
}
