using TowerDefense.Api.Models.Items;
using TowerDefense.Api.Models.Player;

namespace TowerDefense.Api.Battle.Command
{
    public class RemoveCommand : Command, IRevertable
    {
        private readonly int gridItemId;
        private IItem removedItem;

        public RemoveCommand(int gridItemId)
        {
            this.gridItemId = gridItemId;
        }

        public override void Execute(IPlayer player)
        {
            var gridItem = player.ArenaGrid.GridItems[gridItemId];
            removedItem = gridItem.Item;
            gridItem.Item = new Blank();
        }

        public void Undo(IPlayer player)
        {
            var gridItem = player.ArenaGrid.GridItems[gridItemId];
            gridItem.Item = removedItem;
        }
    }
}
