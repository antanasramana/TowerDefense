using TowerDefense.Api.Models.Items;

namespace TowerDefense.Api.Battle.Grid
{
    public static class GridLayout
    {
        public static void CreateGrid(this GridItem[] gridItems, string gridLayout)
        {
            var gridLayoutRemovedWhiteSpace = gridLayout.Where(char.IsDigit).ToArray();

            for (int i = 0; i < gridLayoutRemovedWhiteSpace.Count(); i++)
            {
                var character = gridLayoutRemovedWhiteSpace[i].ToString();
                var type = (ItemType)int.Parse(character);

                gridItems[i] = new GridItem
                {
                    Id = i,
                    ItemType = type,
                    Item = ItemHandler.CreateItem(type)
                };
            }
        }
    }
}
