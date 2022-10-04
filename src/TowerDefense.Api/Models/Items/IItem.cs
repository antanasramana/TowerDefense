namespace TowerDefense.Api.Models.Items
{
    public interface IItem
    {
        string Id { get; set; }
        int Price { get; set; }
        ItemType ItemType { get; set; }

        IItem Clone();
    }
}
