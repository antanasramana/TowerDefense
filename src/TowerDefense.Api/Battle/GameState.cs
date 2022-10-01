using TowerDefense.Api.Constants;
using TowerDefense.Api.Models;

namespace TowerDefense.Api.Battle
{
    public class GameState
    {
        public static GameState Instance { get; } = new();
        public Player[] Players { get; } = new Player[Game.MaxNumberOfPlayers];
        public Dictionary<string, bool> PlayersFinishedTurn { get;  } = new();
        public int ActivePlayers => Players.Count(player => player != null);
        private GameState() { }
    }
}
