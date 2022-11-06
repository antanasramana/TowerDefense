using TowerDefense.Api.Models.Items;

namespace TowerDefense.Api.GameLogic.Factories.ItemFactories
{
    public class ShieldItemFactory : IItemFactory
    {
        public IItem CreateItem()
        {
            return new Shield();
        }
    }
}
