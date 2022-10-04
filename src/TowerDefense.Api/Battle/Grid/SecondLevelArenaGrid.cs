using TowerDefense.Api.Constants;

namespace TowerDefense.Api.Battle.Grid
{
    public class SecondLevelArenaGrid : IArenaGrid
    {
        public GridItem[] GridItems { get; init; } = new GridItem[Game.MaxGridGridItemsForPlayer];

        public SecondLevelArenaGrid()
        {
            const string gridLayout = @"32222222
                                        33222222
                                        33322222
                                        33332222
                                        33333222
                                        33332222
                                        33322222
                                        33222222
                                        32222222";

            GridItems.CreateGrid(gridLayout);
        }
    }
}
