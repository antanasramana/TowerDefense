using TowerDefense.Api.Battle.Grid;

namespace TowerDefense.Api.Strategies
{
    public class GridRow
    {
        public int RowId { get; set; }
        public List<GridItem> GridItems { get; set; }
    }
}
