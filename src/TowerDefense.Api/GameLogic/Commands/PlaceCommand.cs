using TowerDefense.Api.Models.Items;
using TowerDefense.Api.Models.Player;

namespace TowerDefense.Api.GameLogic.Commands
{
    public class PlaceCommand : ICommand
    {
        private readonly string InventoryItemId;
        private readonly int _gridItemId;
        private IItem previousItem;
        public PlaceCommand(string inventoryItemId, int gridItemId)
        {
            InventoryItemId = inventoryItemId;
            _gridItemId = gridItemId;
        }

        public bool Execute(IPlayer player)
        {
            var inventory = player.Inventory;
            var inventoryItem = inventory.Items.FirstOrDefault(x => x.Id == InventoryItemId);

            if (inventoryItem == null) return false;
            inventory.Items.Remove(inventoryItem);

            var selectedGridItem = player.ArenaGrid.GridItems[_gridItemId];
            previousItem = selectedGridItem.Item;
            selectedGridItem.Item = inventoryItem;

            player.Publisher.Attach(selectedGridItem);
            return true;
        }

        public void Undo(IPlayer player)
        {
            var selectedGridItem = player.ArenaGrid.GridItems[_gridItemId];
            player.Publisher.Detach(selectedGridItem);

            player.Inventory.Items.Add(selectedGridItem.Item);

            selectedGridItem.Item = previousItem;
            player.Money += 100;
        }
    }
}
