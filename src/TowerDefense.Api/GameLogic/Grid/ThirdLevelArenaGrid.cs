using TowerDefense.Api.Constants;

namespace TowerDefense.Api.GameLogic.Grid
{
    public class ThirdLevelArenaGrid : IArenaGrid
    {
        public GridItem[] GridItems { get; init; } = new GridItem[Game.MaxGridGridItemsForPlayer];

        public ThirdLevelArenaGrid()
        {
            const string gridLayout = @"33322333
                                        33322333
                                        33322333
                                        22333322
                                        22333322
                                        22333322
                                        22333322
                                        22333322
                                        22233222";

            GridItems.CreateGrid(gridLayout);
        }
    }
}
