using TowerDefense.Api.Models.Items;

namespace TowerDefense.Api.GameLogic.ChainOfResponsibility.ValidationHandlers
{
    public class MoneyValidationHandler : IHandler
    {
        public IHandler NextHandler { get; set; }
        public IItem Handle(Request request)
        {
            var playerMoneyAmount = request.Player.Money;
            var isAbleToAfford = playerMoneyAmount > request.RequiredMoney;
            if (!isAbleToAfford) return null;

            return NextHandler == null ? null : NextHandler.Handle(request);
        }
    }
}
