namespace TowerDefense.Api.Models.Items
{
    public class Plane : IItem
    {
        public string Id { get; set; } = nameof(Plane);
        public int Price { get; set; } = 500;
        public ItemType ItemType { get; set; } = ItemType.Plane;
        public int Health { get; set; } = 50;
        public int Demage { get; set; } = 150;
        public bool CanBeAffectedByAttack { get; set; } = true;
        public IItem Clone()
        {
            return new Plane
            {
                Id = Guid.NewGuid().ToString()
            };
        }
    }
}
