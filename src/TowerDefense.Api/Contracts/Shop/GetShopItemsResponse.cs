using TowerDefense.Api.GameLogic.Items;

namespace TowerDefense.Api.Contracts.Shop
{
    public class GetShopItemsResponse
    {
        public IEnumerable<IItem> Items { get; set; }
    }
}
