using TowerDefense.Api.Models.Items;
using TowerDefense.Api.Models.Player;

namespace TowerDefense.Api.GameLogic.Commands
{
    public class RemoveCommand : ICommand
    {
        private readonly int _gridItemId;
        private IItem removedItem;

        public RemoveCommand(int gridItemId)
        {
            _gridItemId = gridItemId;
        }

        public bool Execute(IPlayer player)
        {
            bool validId = player.ArenaGrid.GridItems.Length > _gridItemId && _gridItemId > 0;
            if (!validId) return false;

            var gridItem = player.ArenaGrid.GridItems[_gridItemId];
            bool canBeRemoved = gridItem.Item.ItemType != ItemType.Blank;
            if (!canBeRemoved) return false;

            removedItem = gridItem.Item;
            gridItem.Item = new Blank();
            return true;
        }

        public void Undo(IPlayer player)
        {
            var gridItem = player.ArenaGrid.GridItems[_gridItemId];
            gridItem.Item = removedItem;
        }
    }
}
