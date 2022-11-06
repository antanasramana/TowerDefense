using TowerDefense.Api.Models.Items;

namespace TowerDefense.Api.GameLogic.Factories.ItemFactories
{
    public class BombItemFactory : IItemFactory
    {
        public IItem CreateItem()
        {
            return new Bomb();
        }
    }
}
