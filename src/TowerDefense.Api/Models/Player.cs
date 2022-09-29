using TowerDefense.Api.Battle.Grid;

namespace TowerDefense.Api.Models
{
    public class Player
    {
        public string ConnectionId { get; set; }
        public string Name { get; set; }
        public int Health { get; set; }
        public int Money { get; set; }
        public Inventory Inventory { get; set; }
        public ArenaGrid ArenaGrid { get; set; }
    }
}
