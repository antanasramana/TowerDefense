using TowerDefense.Api.GameLogic.Grid;
using TowerDefense.Api.Constants;
using TowerDefense.Api.GameLogic.Iterator;

namespace TowerDefense.Api.GameLogic.ArenaAdapter
{
    public class ArenaGridAdapter : IMatrix
    {
        private readonly IArenaGrid _arenaGrid;
        public ArenaGridAdapter(IArenaGrid arenaGrid)
        {
            _arenaGrid = arenaGrid;
        }

        public IIterator GetIterator(int columnId)
        {

            return new MatrixIterator(this, columnId);
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

        public List<GridItem> GetItemsByColumn(int y)
        {
            var columnItemIds = new List<GridItem>();
            for (int i = 0; i < Constants.TowerDefense.MaxGridGridItemsInRow; i++)
            {
                columnItemIds.Add(GetItemByPosition(i, y));
            }

            return columnItemIds;
        }
    }
}
