using TowerDefense.Api.Battle.Shop;
using TowerDefense.Api.Models;

namespace TowerDefense.Api.Battle.Handlers
{
    public interface IShopHandler
    {
        public IShop GetPlayerShop(string playerName);
        void BuyItem(string playerName, string identifier);
    }

    public class ShopHandler : IShopHandler
    {
        private readonly GameState _gameState;

        public ShopHandler()
        {
            _gameState = GameState.Instance;
        }

        public IShop GetPlayerShop(string playerName)
        {
            var player = _gameState.Players.First(player => player.Name == playerName);

            return player.Shop;
        }

        public void BuyItem(string playerName, string identifier)
        {
            var player = _gameState.Players.First(player => player.Name == playerName);
            var item = player.Shop.Items.First(item => item.Id == identifier);

            if (item == null) return;

            var isAbleToAfford = item.Price < player.Money;
            if (!isAbleToAfford) return;

            player.Money -= item.Price;

            player.Inventory.Items.Add(new InventoryItem
            {
                Id = Guid.NewGuid().ToString(),
                ItemType = item.ItemType
            });
        }
    }
}
