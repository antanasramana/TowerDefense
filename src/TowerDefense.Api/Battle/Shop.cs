using TowerDefense.Api.Models;
using TowerDefense.Api.Repositories;

namespace TowerDefense.Api.Battle
{
    public interface IShop
    {
        IEnumerable<Item> AllItems { get; }
        void BuyItem(string identifier, Player player);
    }

    public class Shop : IShop
    {
        private readonly IItemRepository _itemRepository;

        public Shop(IItemRepository itemRepository)
        {
            this._itemRepository = itemRepository;
        }

        public IEnumerable<Item> AllItems => _itemRepository.Items;

        public void BuyItem(string identifier, Player player)
        {
            var item = _itemRepository.Items.First(x => x.Id == identifier);

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
