using TowerDefense.Api.GameLogic.Grid;
using TowerDefense.Api.GameLogic.Iterator;

namespace TowerDefense.Api.GameLogic.ArenaAdapter
{
    public interface IMatrix: IIterableCollection
    {
        GridItem GetItemByPosition(int x, int y);
        List<GridItem> GetItemsByRow(int x);
        List<GridItem> GetItemsByColumn(int x);
    }
}
