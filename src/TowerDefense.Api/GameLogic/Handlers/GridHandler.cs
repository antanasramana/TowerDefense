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
        private readonly State _gameState;

        public GridHandler()
        {
            _gameState = GameOriginator.GameState;
        }
        public IArenaGrid GetGridItems(string playerName)
        {
            var player = _gameState.Players.First(x => x.Name == playerName);
            return player.ArenaGrid;
        }
    }
}
