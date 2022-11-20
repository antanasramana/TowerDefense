using TowerDefense.Api.Models.Items;

namespace TowerDefense.Api.GameLogic.ChainOfResponsibility.ActionHandlers
{
    public class RemoveActionHandler : IHandler
    {
        public IHandler NextHandler { get; set; }
        public IItem Handle(Request request)
        {
            var playersGridItems = request.Player.ArenaGrid.GridItems;

            var gridItemToRemove = playersGridItems[request.GridItemId];

            var removedItem = gridItemToRemove.Item;
            gridItemToRemove.Item = new Blank();

            return NextHandler == null ? removedItem : NextHandler.Handle(request);
        }
    }
}
