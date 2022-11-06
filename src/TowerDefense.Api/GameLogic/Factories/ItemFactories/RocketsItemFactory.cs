using TowerDefense.Api.Models.Items;

namespace TowerDefense.Api.GameLogic.Factories.ItemFactories
{
    public class RocketsItemFactory : IItemFactory
    {
        public IItem CreateItem()
        {
            return new Rockets();
        }
    }
}
