namespace TowerDefense.Api.Models.Items
{
    public static class ItemHandler
    {
        public static IItem CreateItem(ItemType item)
        {
             return item switch
            {
                ItemType.Blank => new Blank(),
                ItemType.Bomb => new Bomb(),
                ItemType.Machinegun => new Machinegun(),
                ItemType.Plane => new Plane(),
                ItemType.Soldier => new Soldier(),
                ItemType.Rockets => new Rockets(),
                ItemType.Shield => new Shield(),
                ItemType.Placeholder => new Placeholder(),
                ItemType.Rock => new Rock(),
                _ => throw new ArgumentOutOfRangeException()
            };
        }
    }
}
