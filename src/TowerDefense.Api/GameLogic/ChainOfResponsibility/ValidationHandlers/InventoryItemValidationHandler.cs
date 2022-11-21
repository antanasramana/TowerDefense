using TowerDefense.Api.Models.Items;

namespace TowerDefense.Api.GameLogic.ChainOfResponsibility.ValidationHandlers
{
    public class InventoryItemValidationHandler : IHandler
    {
        public IHandler NextHandler { get; set; }
        public IItem Handle(Request request)
        {
            var inventory = request.Player.Inventory;
            var inventoryItem = inventory.Items.FirstOrDefault(x => x.Id == request.InventoryId);

            var isValidInventoryItem = inventoryItem != null;
            if (!isValidInventoryItem) return null;

            return NextHandler == null ? null : NextHandler.Handle(request);
        }
    }
}
