using TowerDefense.Api.Models.Items;

namespace TowerDefense.Api.GameLogic.Grid
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
                    Item = ItemHandler.CreateItem(type)
                };
            }
        }
    }
}
