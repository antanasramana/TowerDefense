using TowerDefense.Api.Models.Items;

namespace TowerDefense.Api.GameLogic.Factories.ItemFactories
{
    public interface IItemFactory
    {
        IItem CreateItem();
    }
}
