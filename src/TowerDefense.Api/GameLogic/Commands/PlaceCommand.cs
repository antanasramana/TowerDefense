using TowerDefense.Api.GameLogic.ChainOfResponsibility;
using TowerDefense.Api.GameLogic.ChainOfResponsibility.ActionHandlers;
using TowerDefense.Api.GameLogic.ChainOfResponsibility.ValidationHandlers;
using TowerDefense.Api.Models.Items;
using TowerDefense.Api.Models.Player;

namespace TowerDefense.Api.GameLogic.Commands
{
    public class PlaceCommand : ICommand
    {
        private readonly string _inventoryItemId;
        private readonly int _gridItemId;
        private IItem _previousItem;
        private IHandler _handlerChain;
        public PlaceCommand(string inventoryItemId, int gridItemId)
        {
            _inventoryItemId = inventoryItemId;
            _gridItemId = gridItemId;
        }

        public bool Execute(IPlayer player)
        {
            _handlerChain = CreateChain();
            var chainRequest = CreateChainRequest(player);

            var previousItem = _handlerChain.Handle(chainRequest);
            if (previousItem == null) return false;

            _previousItem = previousItem;
            return true;
        }

        public void Undo(IPlayer player)
        {
            var selectedGridItem = player.ArenaGrid.GridItems[_gridItemId];
            player.Publisher.Detach(selectedGridItem);

            player.Inventory.Items.Add(selectedGridItem.Item);

            selectedGridItem.Item = _previousItem;
        }

        private static IHandler CreateChain()
        {
            var inventoryValidationHandler = new InventoryItemValidationHandler();
            var gridItemValidationHandler = new GridItemValidationHandler();
            var placeActionHandler = new PlaceActionHandler();

            inventoryValidationHandler.NextHandler = gridItemValidationHandler;
            gridItemValidationHandler.NextHandler = placeActionHandler;

            return inventoryValidationHandler;
        }

        private Request CreateChainRequest(IPlayer player)
        {
            return new Request
            {
                GridItemId = _gridItemId,
                InventoryId = _inventoryItemId,
                Player = player
            };
        }
    }
}
