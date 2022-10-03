using TowerDefense.Api.Constants;
using TowerDefense.Api.Models;

namespace TowerDefense.Api.Battle.Grid
{
    public class ThirdLevelArenaGrid : IArenaGrid
    {
        public GridItem[] GridItems { get; init; } = new GridItem[Game.MaxGridTilesForPlayer];

        public ThirdLevelArenaGrid()
        {
            for (int i = 0; i < GridItems.Length; i++)
            {
                GridItems[i] = new GridItem
                {
                    Id = i,
                    ItemType = ItemType.Blank
                };
            }
        }
    }
}
