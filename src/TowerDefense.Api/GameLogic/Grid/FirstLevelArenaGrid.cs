namespace TowerDefense.Api.GameLogic.Grid
{
    public class FirstLevelArenaGrid : IArenaGrid
    {
        public GridItem[] GridItems { get; set; } = new GridItem[Constants.TowerDefense.MaxGridGridItemsForPlayer];

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
