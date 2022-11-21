using TowerDefense.Api.GameLogic.GameState;
using TowerDefense.Api.GameLogic.Shop;

namespace TowerDefense.Api.GameLogic.Handlers
{
    public interface IShopHandler
    {
        public IShop GetPlayerShop(string playerName);
        bool TryBuyItem(string playerName, string identifier);
    }

    public class ShopHandler : IShopHandler
    {
        private readonly GameOriginator _game;

        public ShopHandler()
        {
            _game = GameOriginator.Instance;
        }

        public IShop GetPlayerShop(string playerName)
        {
            var player = _game.State.Players.First(player => player.Name == playerName);

            return player.Shop;
        }

        public bool TryBuyItem(string playerName, string identifier)
        {
            var player = _game.State.Players.First(player => player.Name == playerName);
            var item = player.Shop.Items.First(item => item.Id == identifier);

            if (item == null) return false;

            var isAbleToAfford = item.Stats.Price < player.Money;
            if (!isAbleToAfford) return false;

            player.Money -= item.Stats.Price;

            //PROTOTYPE DESIGN PATTERN!!!!!! WE DONT WANT TO EXPOSE EXACT ITEM ONLY ITS PROPERTIES
            var inventoryItem = item.Clone();
            player.Inventory.Items.Add(inventoryItem);

            return true;
        }
    }
}
