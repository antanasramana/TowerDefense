namespace TowerDefense.Api.Models.Items
{
    public class Shield : IItem
    {
        public string Id { get; set; } = nameof(Shield);
        public int Price { get; set; } = 50;
        public ItemType ItemType { get; set; } = ItemType.Shield;
        public IItem Clone()
        {
            return new Shield
            {
                Id = Guid.NewGuid().ToString()
            };
        }
    }
}
