using TowerDefense.Api.Models.Items;

namespace TowerDefense.Api.GameLogic.Shop
{
    public interface IShop
    {
        public IEnumerable<IItem> Items { get; }
    }
}
