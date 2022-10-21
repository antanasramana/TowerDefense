using TowerDefense.Api.Battle.Builders;
using TowerDefense.Api.Decorator;
using TowerDefense.Api.Models.Items;
using TowerDefense.Api.Models.Player;

namespace TowerDefense.Api.Battle.Command
{
    public class UpgradeCommand : Command, IRevertable
    {
        private readonly int gridItemId;
        private IItem previousItem;

        public UpgradeCommand(int gridItemId)
        {
            this.gridItemId = gridItemId;
        }

        public override void Execute(IPlayer player)
        {
            var gridItem = player.ArenaGrid.GridItems[gridItemId];
            previousItem = gridItem.Item;

            IItem upgradedItem;
            switch (previousItem.Level)
            {
                case 0:
                    upgradedItem = new DamageDecorator(previousItem);
                    break;
                case 2:
                    upgradedItem = new HealthDecorator(previousItem);
                    break;
                default:
                    upgradedItem = new MoneyDecorator(previousItem);
                    break;
            }
            gridItem.Item = upgradedItem;
        }

        public void Undo(IPlayer player)
        {
            var gridItem = player.ArenaGrid.GridItems[gridItemId];
            gridItem.Item = previousItem;
        }
    }
}
