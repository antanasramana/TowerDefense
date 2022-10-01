namespace TowerDefense.Api.Models
{
    public class Item
    {
        public string Id { get; set; }
        public int Price { get; set; }
        public ItemType ItemType { get; set; }
    }
}
