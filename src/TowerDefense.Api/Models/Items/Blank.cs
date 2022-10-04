namespace TowerDefense.Api.Models.Items
{
    public class Blank : IItem
    {
        public string Id { get; set; } = nameof(Blank);
        public int Price { get; set; } = 0;
        public ItemType ItemType { get; set; } = ItemType.Blank;
        public IItem Clone()
        {
            return new Blank()
            {
                Id = Guid.NewGuid().ToString()
            };
        }
    }
}
