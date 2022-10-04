using TowerDefense.Api.Constants;
using TowerDefense.Api.Models;
using TowerDefense.Api.Models.Items;

namespace TowerDefense.Api.Battle.Grid
{
    public class SecondLevelArenaGrid : IArenaGrid
    {
        public GridItem[] GridItems { get; init; } = new GridItem[Game.MaxGridGridItemsForPlayer];

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

        private void AddBlankItemsAndFillRowWithPlaceholder(int countOfBlankGridItems, int rowNumber)
        {
            var startingPointOfBlankGridItems = rowNumber * Game.MaxGridGridItemsInRow;
            for (int i = startingPointOfBlankGridItems; i < startingPointOfBlankGridItems + countOfBlankGridItems; i++)
            {
                GridItems[i] = new GridItem
                {
                    Id = i,
                    ItemType = ItemType.Blank
                };
            }

            var fillInCount = Game.MaxGridGridItemsInRow - countOfBlankGridItems;
            var startingPointOfFillIn = startingPointOfBlankGridItems + countOfBlankGridItems;

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
