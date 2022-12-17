using TowerDefense.Api.GameLogic.GameState;
using TowerDefense.Api.GameLogic.Grid;

namespace TowerDefense.Api.GameLogic.Handlers
{
    public interface IGridHandler
    {
        IArenaGrid GetGridItems(string playerName);
    }

    public class GridHandler : IGridHandler
    {
        private readonly GameOriginator _game;

        public GridHandler()
        {
            _game = GameOriginator.Instance;
        }
        public IArenaGrid GetGridItems(string playerName)
        {
            var player = _game.State.Players.First(x => x.Name == playerName);
            return player.ArenaGrid;
        }
    }
}
