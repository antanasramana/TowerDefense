using TowerDefense.Api.Models.Items;

namespace TowerDefense.Api.GameLogic.ChainOfResponsibility.ValidationHandlers
{
    public class UpgradeValidationHandler : IHandler
    {
        public IHandler NextHandler { get; set; }
        public IItem Handle(Request request)
        {
            var playerGridItems = request.Player.ArenaGrid.GridItems;
            var requestedGridItemId = request.GridItemId;

            var requestedItemToUpgrade = playerGridItems[requestedGridItemId];

            bool isUpgradable = requestedItemToUpgrade.Item.Level < 3;
            if (!isUpgradable) return null;

            return NextHandler == null ? null : NextHandler.Handle(request);
        }
    }
}
