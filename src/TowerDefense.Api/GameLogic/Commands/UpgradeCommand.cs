using TowerDefense.Api.GameLogic.ChainOfResponsibility.ActionHandlers;
using TowerDefense.Api.GameLogic.ChainOfResponsibility.ValidationHandlers;
using TowerDefense.Api.GameLogic.ChainOfResponsibility;
using TowerDefense.Api.Models.Items;
using TowerDefense.Api.Models.Player;

namespace TowerDefense.Api.GameLogic.Commands
{
    public class UpgradeCommand : ICommand
    {
        private readonly int _gridItemId;
        private IItem _itemBeforeUpgrade;
        private IHandler _handlerChain;

        public UpgradeCommand(int gridItemId)
        {
            _gridItemId = gridItemId;
        }

        public bool Execute(IPlayer player)
        {
            _handlerChain = CreateChain();
            var chainRequest = CreateChainRequest(player);

            var itemBeforeUpgrade = _handlerChain.Handle(chainRequest);
            if (itemBeforeUpgrade == null) return false;

            _itemBeforeUpgrade = itemBeforeUpgrade;
            return true;
        }

        public void Undo(IPlayer player)
        {
            var gridItem = player.ArenaGrid.GridItems[_gridItemId];
            gridItem.Item = _itemBeforeUpgrade;
        }

        private static IHandler CreateChain()
        {
            var gridItemValidationHandler = new GridItemValidationHandler();
            var moneyValidationHandler = new MoneyValidationHandler();
            var upgradableValidationHandler = new UpgradeValidationHandler();
            var upgradeActionHandler = new UpgradeActionHandler();

            gridItemValidationHandler.NextHandler = moneyValidationHandler;
            moneyValidationHandler.NextHandler = upgradableValidationHandler;
            upgradableValidationHandler.NextHandler = upgradeActionHandler;

            return gridItemValidationHandler;
        }

        private Request CreateChainRequest(IPlayer player)
        {
            return new Request
            {
                GridItemId = _gridItemId,
                InventoryId = null,
                Player = player,
                RequiredMoney = 100
            };
        }
    }
}
