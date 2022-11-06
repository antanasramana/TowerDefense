using TowerDefense.Api.Models.Items;

namespace TowerDefense.Api.GameLogic.Factories.ItemFactories
{
    public class PlaneItemFactory : IItemFactory
    {
        public IItem CreateItem()
        {
            return new Plane();
        }
    }
}
