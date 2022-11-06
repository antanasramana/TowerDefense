using TowerDefense.Api.Models.Items;

namespace TowerDefense.Api.GameLogic.Factories.ItemFactories
{
    public class SoldierItemFactory : IItemFactory
    {
        public IItem CreateItem()
        {
            return new Soldier();
        }
    }
}
