using TowerDefense.Api.Models;
using TowerDefense.Api.Repositories;

namespace TowerDefense.Api.Battle.Handlers
{
    public interface IShopHandler
    {
        Shop Shop { get; }
        void BuyItem(string identifier, string playerName);
    }

    public class ShopHandler : IShopHandler
    {
        private readonly IItemRepository _itemRepository;
        private readonly GameState _gameState;

        public ShopHandler(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
            _gameState = GameState.Instance;
        }

        public Shop Shop => new() { Items = _itemRepository.Items};

        public void BuyItem(string identifier, string playerName)
        {
            var player = _gameState.Players.First(player => player.Name == playerName);
            var item = _itemRepository.Items.First(item => item.Id == identifier);

            if (item == null) return;

            var isAbleToAfford = item.Price > player.Money;
            if (isAbleToAfford) return;

            player.Money -= item.Price;

            player.Inventory.Items.Add(new InventoryItem
            {
                Id = Guid.NewGuid().ToString(),
                ItemType = item.ItemType
            });
        }
    }
}
