using TowerDefense.Api.Models.Items;

namespace TowerDefense.Api.Battle.Factories.ItemFactories
{
    public class SoldierItemFactory : IItemFactory
    {
        public IItem CreateItem()
        {
            return new Soldier();
        }
    }
}
