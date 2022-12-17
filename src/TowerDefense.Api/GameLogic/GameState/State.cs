using TowerDefense.Api.Enums;
using TowerDefense.Api.Models.Perks;
using TowerDefense.Api.Models.Player;

namespace TowerDefense.Api.GameLogic.GameState
{
    public class State
    {
        public IPlayer[] Players { get; } = new IPlayer[Constants.TowerDefense.MaxNumberOfPlayers];
        public Dictionary<string, bool> PlayersFinishedTurn { get; } = new();
        public int ActivePlayers => Players.Count(player => player != null);
        public List<(string PlayerName, IPerk Perk)> PerksUsedOnPlayer { get; set; } = new();
        public Level Level { get; set; }
    }
}
