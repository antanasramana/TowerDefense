using TowerDefense.Api.GameLogic.Decorator;
using TowerDefense.Api.Models.Items;

namespace TowerDefense.Api.GameLogic.ChainOfResponsibility.ActionHandlers
{
    public class UpgradeActionHandler : IHandler
    {
        public IHandler NextHandler { get; set; }
        public IItem Handle(Request request)
        {
            var playersGridItems = request.Player.ArenaGrid.GridItems;

            var gridItemToUpgrade = playersGridItems[request.GridItemId];
            var itemBeforeUpgrade = gridItemToUpgrade.Item;

            IItem upgradedItem = itemBeforeUpgrade.Level switch
            {
                0 => new DamageDecorator(itemBeforeUpgrade),
                1 => new MoneyDecorator(itemBeforeUpgrade),
                _ => new HealthDecorator(itemBeforeUpgrade)
            };

            gridItemToUpgrade.Item = upgradedItem;

            upgradedItem.Stats.Price += request.RequiredMoney;
            request.Player.Money -= request.RequiredMoney;

            return NextHandler == null ? itemBeforeUpgrade : NextHandler.Handle(request);
        }
    }
}
