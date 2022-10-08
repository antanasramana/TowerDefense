namespace TowerDefense.Api.Models.Items
{
    public class Rock : IItem
    {
        public string Id { get; set; } = nameof(Rock);
        public int Price { get; set; } = 20;
        public ItemType ItemType { get; set; } = ItemType.Rock;
        public int Health { get; set; } = 150;
        public int Demage { get; set; } = 0;
        public bool CanBeAffectedByAttack { get; set; } = true;
        public IItem Clone()
        {
            return new Rock()
            {
                Id = Guid.NewGuid().ToString()
            };
        }
    }
}
