using TowerDefense.Api.Models.Items;

namespace TowerDefense.Api.Battle.Factories.ItemFactories
{
    public class ShieldItemFactory : IItemFactory
    {
        public IItem CreateItem()
        {
            return new Shield();
        }
    }
}
