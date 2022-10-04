using TowerDefense.Api.Models.Items;

namespace TowerDefense.Api.Battle.Factories.ItemFactories
{
    public class RocketsItemFactory : IItemFactory
    {
        public IItem CreateItem()
        {
            return new Rockets();
        }
    }
}
