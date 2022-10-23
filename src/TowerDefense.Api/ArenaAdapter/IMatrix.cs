using TowerDefense.Api.Battle.Grid;

namespace TowerDefense.Api.ArenaAdapter
{
    public interface IMatrix
    {
        GridItem GetItemByPosition(int x, int y);
        List<GridItem> GetItemsByRow(int x);
    }
}
