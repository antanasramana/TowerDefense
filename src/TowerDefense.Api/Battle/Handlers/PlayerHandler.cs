using TowerDefense.Api.Models.Player;

namespace TowerDefense.Api.Battle.Handlers
{
    public interface IPlayerHandler
    {
        IPlayer GetPlayer(string playerName);
    }

    public class PlayerHandler : IPlayerHandler
    {
        private readonly GameState _gameState;

        public PlayerHandler()
        {
            _gameState = GameState.Instance;
        }

        public IPlayer GetPlayer(string playerName)
        {
            return _gameState.Players.First(player => player.Name == playerName);
        }
    }
}
