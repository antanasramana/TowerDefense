using TowerDefense.Api.Battle.Grid;
using TowerDefense.Api.Strategies.RocketStrategy;

namespace TowerDefense.Api.Models.Items
{
    public class Rockets : IItem
    {
        public string Id { get; set; } = nameof(Rockets);
        public int Price { get; set; } = 100;

        public ItemType ItemType { get; set; } = ItemType.Rockets;
        public IRocketsStrategy Strategy { get; set; }
        public int Health { get; set; } = 25;
        public int Demage { get; set; } = 25;
        public bool CanBeAffectedByAttack { get; set; } = true;
        public IItem Clone()
        {
            return new Rockets
            {
                Id = Guid.NewGuid().ToString()
            };
        }
    }
}
