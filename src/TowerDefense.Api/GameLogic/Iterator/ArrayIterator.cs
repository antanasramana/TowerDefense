using System.Linq;
using TowerDefense.Api.GameLogic.ArenaAdapter;
using TowerDefense.Api.GameLogic.Grid;

namespace TowerDefense.Api.GameLogic.Iterator
{
    public class ArrayIterator : IIterator
    {
        private IArenaGrid arenaGrid;
        private int index;
        private GridItem[] items;

        public ArrayIterator(IArenaGrid array, int index)
        {
            this.arenaGrid = array;
            var rowItemIds = Enumerable.Range(index * Constants.TowerDefense.MaxGridGridItemsInRow, Constants.TowerDefense.MaxGridGridItemsInRow);
            items = this.arenaGrid.GridItems.Where(x => rowItemIds.Contains(x.Id)).OrderByDescending(x => x.Id).ToArray();
            index = 0;

        }
        public GridItem GetNext()
        {
            if (HasMore())
                return items[index++];
            return null;
        }

        public GridItem GetPrevious()
        {
            if (!IsLast())
                return items[index++];
            return null;
        }

        public bool HasMore()
        {
            return items.Length > index;
        }

        public bool IsLast()
        {
            return 0 < index;
        }
    }
}
