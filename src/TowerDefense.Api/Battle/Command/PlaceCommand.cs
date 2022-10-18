using TowerDefense.Api.Battle.Grid;
using TowerDefense.Api.Models;
using TowerDefense.Api.Models.Player;

namespace TowerDefense.Api.Battle.Command
{
    public class PlaceCommand : Command, IRevertable
    {
        private readonly string itemId;
        private readonly int gridId;
        public PlaceCommand(IPlayer player, string itemId, int gridId) : base(player)
        {
            this.itemId = itemId;
            this.gridId = gridId;
        }

        protected override bool canBeUndone => throw new NotImplementedException();

        public override void Execute()
        {
            var inventory = player.Inventory;
            var inventoryItem = inventory.Items.FirstOrDefault(x => x.Id == itemId);

            if (inventoryItem == null) return;
            inventory.Items.Remove(inventoryItem);

            var selectedGridItem = player.ArenaGrid.GridItems[gridId];
            selectedGridItem.Item = inventoryItem;

            player.Publisher.Attach(selectedGridItem);
        }

        public void Undo()
        {
            var selectedGridItem = player.ArenaGrid.GridItems[gridId];
            player.Publisher.Detach(selectedGridItem);

            player.Inventory.Items.Add(selectedGridItem.Item);
        }
    }
}
