using TowerDefense.Api.GameLogic.Factories.ItemFactories;
using TowerDefense.Api.Models.Items;

namespace TowerDefense.Api.GameLogic.Shop
{
    public class FirstLevelShop : IShop
    {
        private readonly IEnumerable<IItemFactory> _itemFactories = new List<IItemFactory>
        {
            new RocketsItemFactory(),
            new ShieldItemFactory()
        };

        public IEnumerable<IItem> Items => _itemFactories.Select(x => x.CreateItem()).ToList();
    }
}
