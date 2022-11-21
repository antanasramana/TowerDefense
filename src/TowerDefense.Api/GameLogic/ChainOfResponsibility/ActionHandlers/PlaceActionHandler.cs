using TowerDefense.Api.Models.Items;

namespace TowerDefense.Api.GameLogic.ChainOfResponsibility.ActionHandlers
{
    public class PlaceActionHandler : IHandler
    {
        public IHandler NextHandler { get; set; }
        public IItem Handle(Request request)
        {
            var inventory = request.Player.Inventory;
            var requestedItem = inventory.Items.FirstOrDefault(x => x.Id == request.InventoryId);

            var playersGridItems = request.Player.ArenaGrid.GridItems;
            var selectedGridItem = playersGridItems[request.GridItemId];

            inventory.Items.Remove(requestedItem);
            var previousItem = selectedGridItem.Item;

            selectedGridItem.Item = requestedItem;
            request.Player.Publisher.Attach(selectedGridItem);

            return NextHandler == null ? previousItem : NextHandler.Handle(request);
        }
    }
}
