using TowerDefense.Api.Models.Items;

namespace TowerDefense.Api.GameLogic.ChainOfResponsibility.ValidationHandlers
{
    public class RemoveValidationHandler : IHandler
    {
        public IHandler NextHandler { get; set; }
        public IItem Handle(Request request)
        {
            var playerGridItems = request.Player.ArenaGrid.GridItems;
            var requestedGridItemId = request.GridItemId;

            var gridItem = playerGridItems[requestedGridItemId];
            var canBeRemoved = gridItem.Item.ItemType != ItemType.Blank;
            if (!canBeRemoved) return null;

            return NextHandler == null ? null : NextHandler.Handle(request);
        }
    }
}
