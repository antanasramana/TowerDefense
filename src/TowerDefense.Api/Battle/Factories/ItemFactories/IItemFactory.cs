using TowerDefense.Api.Models.Items;

namespace TowerDefense.Api.Battle.Factories.ItemFactories
{
    public interface IItemFactory
    {
        IItem CreateItem();
    }
}
