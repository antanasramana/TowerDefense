using TowerDefense.Api.Battle.Observer;
using TowerDefense.Api.Constants;
using TowerDefense.Api.Enums;
using TowerDefense.Api.Models.Player;

namespace TowerDefense.Api.Battle
{
    public class GameState
    {
        public static GameState Instance { get; } = new();
        public IPlayer[] Players { get; } = new IPlayer[Game.MaxNumberOfPlayers];
        public Dictionary<string, bool> PlayersFinishedTurn { get;  } = new();
        public int ActivePlayers => Players.Count(player => player != null);
        public Level Level { get; set; }
        public IGridPublisher[] GridPublishers { get; } = new IGridPublisher[Game.MaxNumberOfPlayers];
        private GameState() { }
    }
}
