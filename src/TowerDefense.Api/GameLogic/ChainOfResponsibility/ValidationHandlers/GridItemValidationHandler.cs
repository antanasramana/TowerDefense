using TowerDefense.Api.Models.Items;

namespace TowerDefense.Api.GameLogic.ChainOfResponsibility.ValidationHandlers
{
    public class GridItemValidationHandler : IHandler
    {
        public IHandler NextHandler { get; set; }
        public IItem Handle(Request request)
        {
            var playerGridItems = request.Player.ArenaGrid.GridItems;
            var requestedGridItemId = request.GridItemId;

            var isValidId = playerGridItems.Length > requestedGridItemId && requestedGridItemId > 0;
            if (!isValidId) return null;

            return NextHandler == null ? null : NextHandler.Handle(request);
        }
    }
}
