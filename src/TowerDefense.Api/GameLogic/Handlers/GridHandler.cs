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
        private readonly Game _game;
        private readonly IInventoryHandler _inventoryHandler;

        public GridHandler(IInventoryHandler inventoryHandler)
        {
            _game = Game.Instance;
            _inventoryHandler = inventoryHandler;
        }
        public IArenaGrid GetGridItems(string playerName)
        {
            var player = _game.State.Players.First(x => x.Name == playerName);
            return player.ArenaGrid;
        }
    }
}
