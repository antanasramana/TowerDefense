using TowerDefense.Api.Battle.Grid;
using TowerDefense.Api.Models;
using TowerDefense.Api.Models.Items;
using TowerDefense.Api.Models.Player;

namespace TowerDefense.Api.Battle.Command
{
    public class PlaceCommand : Command, IRevertable
    {
        private readonly string inventoryItemId;
        private readonly int gridItemId;
        private IItem previousItem;
        public PlaceCommand(string inventoryItemId, int gridItemId)
        {
            this.inventoryItemId = inventoryItemId;
            this.gridItemId = gridItemId;
        }

        public override void Execute(IPlayer player)
        {
            var inventory = player.Inventory;
            var inventoryItem = inventory.Items.FirstOrDefault(x => x.Id == inventoryItemId);

            if (inventoryItem == null) return;
            inventory.Items.Remove(inventoryItem);

            var selectedGridItem = player.ArenaGrid.GridItems[gridItemId];
            previousItem = selectedGridItem.Item;
            selectedGridItem.Item = inventoryItem;

            player.Publisher.Attach(selectedGridItem);
        }

        public void Undo(IPlayer player)
        {
            var selectedGridItem = player.ArenaGrid.GridItems[gridItemId];
            player.Publisher.Detach(selectedGridItem);

            player.Inventory.Items.Add(selectedGridItem.Item);

            selectedGridItem.Item = previousItem;
        }
    }
}
