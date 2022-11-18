using TowerDefense.Api.GameLogic.Grid;
using TowerDefense.Api.Constants;

namespace TowerDefense.Api.GameLogic.ArenaAdapter
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
            var isOutOfBounds = x < 0 || x > Constants.TowerDefense.MaxGridItemsInColumn || y < 0 || y > Constants.TowerDefense.MaxGridGridItemsInRow - 1;
            if (isOutOfBounds)
            {
                return null;
            }

            return _arenaGrid.GridItems[x * Constants.TowerDefense.MaxGridGridItemsInRow + y];
        }

        public List<GridItem> GetItemsByRow(int x)
        {
            var rowItemIds = Enumerable.Range(0, Constants.TowerDefense.MaxGridGridItemsInRow)
                                       .Select(i => i + (x * Constants.TowerDefense.MaxGridGridItemsInRow));
            var gridItems = _arenaGrid.GridItems.Where(x => rowItemIds.Contains(x.Id)).ToList();
            
            return gridItems;
        }
    }
}
