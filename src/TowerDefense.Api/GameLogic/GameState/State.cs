using TowerDefense.Api.GameLogic.Perks;
using TowerDefense.Api.GameLogic.Player;

namespace TowerDefense.Api.GameLogic.GameState
{
    public class State
    {
        public IPlayer[] Players { get; } = new IPlayer[Constants.TowerDefense.MaxNumberOfPlayers];
        public Dictionary<string, bool> PlayersFinishedTurn { get; } = new();
        public int ActivePlayers => Players.Count(player => player != null);
        public List<(string PlayerName, IPerk Perk)> PerksUsedOnPlayer { get; set; } = new();
    }
}
