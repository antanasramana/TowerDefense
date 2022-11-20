using TowerDefense.Api.GameLogic.ChainOfResponsibility.ActionHandlers;
using TowerDefense.Api.GameLogic.ChainOfResponsibility.ValidationHandlers;
using TowerDefense.Api.GameLogic.ChainOfResponsibility;
using TowerDefense.Api.Models.Items;
using TowerDefense.Api.Models.Player;

namespace TowerDefense.Api.GameLogic.Commands
{
    public class RemoveCommand : ICommand
    {
        private readonly int _gridItemId;
        private IItem _removedItem;

        public RemoveCommand(int gridItemId)
        {
            _gridItemId = gridItemId;
        }

        public bool Execute(IPlayer player)
        {
            var chainRequest = CreateChainRequest(player);
            var handlerChain = CreateChain();

            var removedItem = handlerChain.Handle(chainRequest);
            if (removedItem == null) return false;

            _removedItem = removedItem;
            return true;
        }

        public void Undo(IPlayer player)
        {
            var gridItem = player.ArenaGrid.GridItems[_gridItemId];
            gridItem.Item = _removedItem;
        }

        private static IHandler CreateChain()
        {
            var gridItemValidationHandler = new GridItemValidationHandler();
            var removeValidationHandler = new RemoveValidationHandler();
            var removeActionHandler = new RemoveActionHandler();

            gridItemValidationHandler.NextHandler = removeValidationHandler;
            removeValidationHandler.NextHandler = removeActionHandler;

            return removeValidationHandler;
        }

        private Request CreateChainRequest(IPlayer player)
        {
            return new Request
            {
                GridItemId = _gridItemId,
                InventoryId = null,
                Player = player
            };
        }
    }
}
