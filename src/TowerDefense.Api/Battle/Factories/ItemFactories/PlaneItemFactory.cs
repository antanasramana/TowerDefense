using TowerDefense.Api.Models.Items;

namespace TowerDefense.Api.Battle.Factories.ItemFactories
{
    public class PlaneItemFactory : IItemFactory
    {
        public IItem CreateItem()
        {
            return new Plane();
        }
    }
}
