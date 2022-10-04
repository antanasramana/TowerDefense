using TowerDefense.Api.Constants;
using TowerDefense.Api.Models;
using TowerDefense.Api.Models.Items;

namespace TowerDefense.Api.Battle.Grid
{
    public class FirstLevelArenaGrid : IArenaGrid
    {
        public GridItem[] GridItems { get; init; } = new GridItem[Game.MaxGridGridItemsForPlayer];

        public FirstLevelArenaGrid()
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
