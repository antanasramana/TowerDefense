using TowerDefense.Api.Models.Items;
using TowerDefense.Api.Models.Player;

namespace TowerDefense.Api.GameLogic.Commands
{
    public class GiveItemCommand : ICommand
    {
        private readonly ItemType _itemType;
        private readonly int _count;

        public GiveItemCommand(ItemType itemType, int count)
        {
            _itemType = itemType;
            _count = count;
        }

        public bool Execute(IPlayer player)
        {
            IItem item = ItemHandler.CreateItem(_itemType);
            if (item == null)
            {
                return false;
            }
            for (int i = 0; i < _count; i++)
            {
                player.Inventory.Items.Add(item);
            }

            return false;
        }

        public void Undo(IPlayer player)
        {
            return;
        }
    }
}
