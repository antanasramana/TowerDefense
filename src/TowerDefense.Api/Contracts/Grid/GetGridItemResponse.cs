using TowerDefense.Api.Models.Items;

namespace TowerDefense.Api.Contracts.Grid
{
    public class GetGridItemResponse
    {
        public int Id { get; set; }
        public ItemType ItemType { get; set; }
        public int Level { get; set; }
        public int Health { get; set; }
        public int Damage { get; set; }
        public IEnumerable<string> PowerUps { get; set; }
    }
}
