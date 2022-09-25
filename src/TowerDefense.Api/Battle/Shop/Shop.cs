namespace TowerDefense.Api.Battle.Shop
{
    public class BattleShop
    {
        private readonly IItemRepository shopRepository;

        public BattleShop(IItemRepository shopRepository)
        {
            this.shopRepository = shopRepository;
        }
        public List<Item> GetItems()
        {
            return shopRepository.GetItems();
        }

        public void BuyItem(string identifier, Player player)
        {
            Item item = shopRepository.GetItems().Find(x => x.Id == identifier);

            if (item == null)
            {
                return;
            }

            if (item.Price > player.Money)
            {
                return;
            }

            player.Money -= item.Price;

            player.Inventory.Items.Add(new InventoryItem
            {
                Id = Guid.NewGuid().ToString(),
                ItemType = item.ItemType
            });
        }
    }
}
