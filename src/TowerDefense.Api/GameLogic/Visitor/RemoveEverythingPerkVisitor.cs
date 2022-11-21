using System.Diagnostics;
using TowerDefense.Api.GameLogic.Grid;
using TowerDefense.Api.Models;
using TowerDefense.Api.Models.Items;
using TowerDefense.Api.Models.Player;

namespace TowerDefense.Api.GameLogic.Visitor
{
    public class RemoveEverythingPerkVisitor : IVisitor
    {
        public void Visit(Inventory inventory)
        {
            inventory.Items = new List<IItem>();
        }

        public void Visit(IPlayer player)
        {
            player.Armor = 0;
            player.Money = 0;
        }

        public void Visit(IArenaGrid arenaGrid)
        {
            foreach (var gridItem in arenaGrid.GridItems)
            {
                gridItem.Item = gridItem.ItemType switch
                {
                    ItemType.Placeholder => new Placeholder(),
                    _ => new Blank()
                };
            }
        }
    }
}
