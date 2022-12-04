using TowerDefense.Api.GameLogic.ArenaAdapter;
using TowerDefense.Api.GameLogic.Grid;

namespace TowerDefense.Api.GameLogic.Iterator
{
    public class MatrixIterator : IIterator
    {
        private IMatrix matrix;
        private int index;
        private GridItem[] items;

        public MatrixIterator(IMatrix matrix, int index)
        {
            this.matrix = matrix;
            items = this.matrix.GetItemsByRow(index).OrderByDescending(x => x.Id).ToArray();
            this.index = 0;

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
