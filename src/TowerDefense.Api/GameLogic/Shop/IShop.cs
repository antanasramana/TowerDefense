using TowerDefense.Api.GameLogic.Items;

namespace TowerDefense.Api.GameLogic.Shop
{
    public interface IShop
    {
        public IEnumerable<IItem> Items { get; }
    }
}
