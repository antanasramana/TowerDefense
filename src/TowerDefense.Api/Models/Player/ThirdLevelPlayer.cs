using TowerDefense.Api.GameLogic.Commands;
using TowerDefense.Api.GameLogic.Grid;
using TowerDefense.Api.GameLogic.Observer;
using TowerDefense.Api.GameLogic.PerkStorage;
using TowerDefense.Api.GameLogic.Shop;
using TowerDefense.Api.GameLogic.Visitor;

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
        public IPerkStorage PerkStorage { get; set; } = null;
        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
