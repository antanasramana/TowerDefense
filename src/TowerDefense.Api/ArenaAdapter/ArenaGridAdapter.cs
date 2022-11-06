using TowerDefense.Api.GameLogic.Grid;
using TowerDefense.Api.Constants;

namespace TowerDefense.Api.ArenaAdapter
{
    public class ArenaGridAdapter : IMatrix
    {
        private readonly IArenaGrid _arenaGrid;
        public ArenaGridAdapter(IArenaGrid arenaGrid)
        {
            _arenaGrid = arenaGrid;
        }

        public GridItem GetItemByPosition(int x, int y)
        {
            var isOutOfBounds = x < 0 || x > Game.MaxGridItemsInColumn || y < 0 || y > Game.MaxGridGridItemsInRow - 1;
            if (isOutOfBounds)
            {
                return null;
            }

            return _arenaGrid.GridItems[x * Game.MaxGridGridItemsInRow + y];
        }

        public List<GridItem> GetItemsByRow(int x)
        {
            var rowItemIds = Enumerable.Range(0, Game.MaxGridGridItemsInRow)
                                       .Select(i => i + (x * Game.MaxGridGridItemsInRow));
            var gridItems = _arenaGrid.GridItems.Where(x => rowItemIds.Contains(x.Id)).ToList();
            
            return gridItems;
        }
    }
}
