using TowerDefense.Api.Models;

namespace TowerDefense.Api.Battle.Shop
{
    public interface IShop
    {
        public IEnumerable<Item> Items { get; }
    }
}
