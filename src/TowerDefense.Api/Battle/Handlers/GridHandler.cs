using TowerDefense.Api.GameLogic.Grid;

namespace TowerDefense.Api.GameLogic.Handlers
{
    public interface IGridHandler
    {
        IArenaGrid GetGridItems(string playerName);
    }

    public class GridHandler : IGridHandler
    {
        private readonly GameState _gameState;
        private readonly IInventoryHandler _inventoryHandler;

        public GridHandler(IInventoryHandler inventoryHandler)
        {
            _gameState = GameState.Instance;
            _inventoryHandler = inventoryHandler;
        }
        public IArenaGrid GetGridItems(string playerName)
        {
            var player = _gameState.Players.First(x => x.Name == playerName);
            return player.ArenaGrid;
        }
    }
}
