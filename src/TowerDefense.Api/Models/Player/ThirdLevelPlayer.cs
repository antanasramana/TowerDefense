using TowerDefense.Api.Battle.Commands;
using TowerDefense.Api.Battle.Commands;
using TowerDefense.Api.Battle.Grid;
using TowerDefense.Api.Battle.Observer;
using TowerDefense.Api.Battle.Shop;

namespace TowerDefense.Api.Models.Player
{
    public class ThirdlevelPlayer : IPlayer
    {
        public string ConnectionId { get; set; }
        public string Name { get; set; }
        public int Health { get; set; } = 40;
        public int Armor { get; set; } = 40;
        public int Money { get; set; } = 3000;
        public Inventory Inventory { get; set; } = new Inventory();
        public IArenaGrid ArenaGrid { get; set; } = null;
        public IShop Shop { get; set; } = null;
        public IGridPublisher Publisher { get; set; } = new GridPublisher();
        public ICommandHistory CommandHistory { get; set; } = new CommandHistory();
    }
}
