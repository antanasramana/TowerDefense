using TowerDefense.Api.Models.Items;

namespace TowerDefense.Api.Battle.Factories.ItemFactories
{
    public class BombItemFactory : IItemFactory
    {
        public IItem CreateItem()
        {
            return new Bomb();
        }
    }
}
