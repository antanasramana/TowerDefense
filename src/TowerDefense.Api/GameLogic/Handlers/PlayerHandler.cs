using TowerDefense.Api.GameLogic.GameState;
using TowerDefense.Api.Models.Player;

namespace TowerDefense.Api.GameLogic.Handlers
{
    public interface IPlayerHandler
    {
        IPlayer GetPlayer(string playerName);
    }

    public class PlayerHandler : IPlayerHandler
    {
        private readonly GameOriginator _game;

        public PlayerHandler()
        {
            _game = GameOriginator.Instance;
        }

        public IPlayer GetPlayer(string playerName)
        {
            return _game.State.Players.First(player => player.Name == playerName);
        }
    }
}
