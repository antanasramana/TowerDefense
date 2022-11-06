using TowerDefense.Api.GameLogic.Grid;
using TowerDefense.Api.Models;
using TowerDefense.Api.Models.Items;
using TowerDefense.Api.Models.Player;

namespace TowerDefense.Api.GameLogic.Commands
{
    public class PlaceCommand : ICommand
    {
        private readonly string _inventoryItemId;
        private readonly int _gridItemId;
        private IItem previousItem;
        public PlaceCommand(string inventoryItemId, int gridItemId)
        {
            _inventoryItemId = inventoryItemId;
            _gridItemId = gridItemId;
        }

        public bool Execute(IPlayer player)
        {
            var inventory = player.Inventory;
            var inventoryItem = inventory.Items.FirstOrDefault(x => x.Id == _inventoryItemId);

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
        }
    }
}
