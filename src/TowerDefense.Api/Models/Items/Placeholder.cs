namespace TowerDefense.Api.Models.Items
{
    public class Placeholder : IItem
    {
        public string Id { get; set; } = nameof(Placeholder);
        public int Price { get; set; } = 0;
        public ItemType ItemType { get; set; } = ItemType.Placeholder;
        public int Health { get; set; } = 0;
        public int Demage { get; set; } = 0;
        public bool CanBeAffectedByAttack { get; set; } = false;
        public IItem Clone()
        {
            return new Placeholder
            {
                Id = Guid.NewGuid().ToString()
            };
        }
    }
}
