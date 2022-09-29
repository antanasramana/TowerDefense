using TowerDefense.Api.Models;

namespace TowerDefense.Api.Battle.Grid
{
    public class ArenaGrid
    {
        public GridItem[] GridItems = new GridItem[72];

        public ArenaGrid()
        {
            for (int i = 0; i < GridItems.Length; i++)
            {
                GridItems[i] = new GridItem
                {
                    Id = i,
                    ItemType= ItemType.Blank
                };
            }
        }
    }
}
