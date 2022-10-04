using TowerDefense.Api.Constants;

namespace TowerDefense.Api.Battle.Grid
{
    public class FirstLevelArenaGrid : IArenaGrid
    {
        public GridItem[] GridItems { get; init; } = new GridItem[Game.MaxGridGridItemsForPlayer];

        public FirstLevelArenaGrid()
        {
            const string gridLayout = @"33333333
                                        33333333
                                        33333333
                                        33333333
                                        33333333
                                        33333333
                                        33333333
                                        33333333
                                        33333333";

            GridItems.CreateGrid(gridLayout);
        }
    }
}
