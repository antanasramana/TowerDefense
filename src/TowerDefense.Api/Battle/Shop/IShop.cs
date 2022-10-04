using TowerDefense.Api.Models;
using TowerDefense.Api.Models.Items;

namespace TowerDefense.Api.Battle.Shop
{
    public interface IShop
    {
        public IEnumerable<IItem> Items { get; }
    }
}
