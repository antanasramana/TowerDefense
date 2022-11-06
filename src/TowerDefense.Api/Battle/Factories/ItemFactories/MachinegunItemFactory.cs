using TowerDefense.Api.Models.Items;

namespace TowerDefense.Api.GameLogic.Factories.ItemFactories
{
    public class MachinegunItemFactory : IItemFactory
    {
        public IItem CreateItem()
        {
            return new Machinegun();
        }
    }
}
