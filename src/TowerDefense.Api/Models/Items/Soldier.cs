namespace TowerDefense.Api.Models.Items
{
    public class Soldier : IItem
    {
        public string Id { get; set; } = nameof(Soldier);
        public int Price { get; set; } = 150;
        public ItemType ItemType { get; set; } = ItemType.Soldier;
        public int Health { get; set; } = 10;
        public int Demage { get; set; } = 25;
        public bool CanBeAffectedByAttack { get; set; } = true;
        public IItem Clone()
        {
            return new Soldier
            {
                Id = Guid.NewGuid().ToString()
            };
        }
    }
}
