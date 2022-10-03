using TowerDefense.Api.Constants;
using TowerDefense.Api.Models;

namespace TowerDefense.Api.Battle.Grid
{
    public class SecondLevelArenaGrid : IArenaGrid
    {
        public GridItem[] GridItems { get; init; } = new GridItem[Game.MaxGridTilesForPlayer];

        public SecondLevelArenaGrid()
        {
            AddBlankItemsAndFillRowWithPlaceholder(1, 0);
            AddBlankItemsAndFillRowWithPlaceholder(2, 1);
            AddBlankItemsAndFillRowWithPlaceholder(3, 2);
            AddBlankItemsAndFillRowWithPlaceholder(4, 3);
            AddBlankItemsAndFillRowWithPlaceholder(5, 4);
            AddBlankItemsAndFillRowWithPlaceholder(4, 5);
            AddBlankItemsAndFillRowWithPlaceholder(3, 6);
            AddBlankItemsAndFillRowWithPlaceholder(2, 7);
            AddBlankItemsAndFillRowWithPlaceholder(1, 8);
        }

        private void AddBlankItemsAndFillRowWithPlaceholder(int countOfBlankTiles, int rowNumber)
        {
            var startingPointOfBlankTiles = rowNumber * Game.MaxGridTilesInRow;
            for (int i = startingPointOfBlankTiles; i < startingPointOfBlankTiles + countOfBlankTiles; i++)
            {
                GridItems[i] = new GridItem
                {
                    Id = i,
                    ItemType = ItemType.Blank
                };
            }

            var fillInCount = Game.MaxGridTilesInRow - countOfBlankTiles;
            var startingPointOfFillIn = startingPointOfBlankTiles + countOfBlankTiles;

            for (int i = startingPointOfFillIn; i < startingPointOfFillIn + fillInCount; i++)
            {
                GridItems[i] = new GridItem
                {
                    Id = i,
                    ItemType = ItemType.Placeholder
                };
            }
        }
    }
}
