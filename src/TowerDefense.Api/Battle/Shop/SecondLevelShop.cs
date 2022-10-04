using TowerDefense.Api.Battle.Factories.ItemFactories;
using TowerDefense.Api.Models.Items;

namespace TowerDefense.Api.Battle.Shop
{
    public class SecondLevelShop : IShop
    {
        private readonly IEnumerable<IItemFactory> _itemFactories = new List<IItemFactory>
        {
            new RocketsItemFactory(),
            new ShieldItemFactory(),
            new SoldierItemFactory(),
            new MachinegunItemFactory()
        };

        public IEnumerable<IItem> Items => _itemFactories.Select(x => x.CreateItem()).ToList();
    }
}
