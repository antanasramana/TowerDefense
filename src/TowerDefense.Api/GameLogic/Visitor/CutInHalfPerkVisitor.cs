using TowerDefense.Api.GameLogic.Grid;
using TowerDefense.Api.Models;
using TowerDefense.Api.Models.Items;
using TowerDefense.Api.Models.Player;

namespace TowerDefense.Api.GameLogic.Visitor
{
    public class CutInHalfPerkVisitor : IVisitor
    {
        public void Visit(Inventory inventory)
        {
            inventory.Items = inventory.Items.Where((_, index) => index % 2 == 0).ToList();
        }

        public void Visit(IPlayer player)
        {
            player.Armor /= 2;
            player.Health /= 2;
            player.Money /= 2;
        }

        public void Visit(IArenaGrid arenaGrid)
        {
            foreach (var gridItem in arenaGrid.GridItems.Where((_, index) => index % 2 == 0))
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
