using TowerDefense.Api.Battle.Builders;
using TowerDefense.Api.Decorator;
using TowerDefense.Api.Models.Items;
using TowerDefense.Api.Models.Player;

namespace TowerDefense.Api.Battle.Commands
{
    public class UpgradeCommand : ICommand
    {
        private readonly int _gridItemId;
        private IItem previousItem;

        public UpgradeCommand(int gridItemId)
        {
            _gridItemId = gridItemId;
        }

        public bool Execute(IPlayer player)
        {
            // Lots of IF statements which repeat in other commands.
            // Maybe Chain of responsibility could be used?
            bool validId = player.ArenaGrid.GridItems.Length > _gridItemId && _gridItemId > 0;
            if (!validId) return false;

            var gridItem = player.ArenaGrid.GridItems[_gridItemId];
            previousItem = gridItem.Item;

            bool isUpgradeable = previousItem.Level < 3;
            if (!isUpgradeable) return false;


            IItem upgradedItem = previousItem.Level switch
            {
                0 => new DamageDecorator(previousItem),
                1 => new MoneyDecorator(previousItem),
                _ => new HealthDecorator(previousItem)
            };

            gridItem.Item = upgradedItem;

            return true;
        }

        public void Undo(IPlayer player)
        {
            var gridItem = player.ArenaGrid.GridItems[_gridItemId];
            gridItem.Item = previousItem;
        }
    }
}
