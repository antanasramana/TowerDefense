using TowerDefense.Api.GameLogic.GameState;
using TowerDefense.Api.Models.Player;

namespace TowerDefense.Api.GameLogic.Handlers
{
    public interface IPlayerHandler
    {
        IPlayer GetPlayer(string playerName);
        IEnumerable<IPlayer> GetPlayers();
    }

    public class PlayerHandler : IPlayerHandler
    {
        private readonly State _gameState;

        public PlayerHandler()
        {
            _gameState = GameOriginator.GameState;
        }

        public IPlayer GetPlayer(string playerName)
        {
            return _gameState.Players.First(player => player.Name == playerName);
        }
        public IEnumerable<IPlayer> GetPlayers()
        {
            return _gameState.Players;
        }
    }
}
