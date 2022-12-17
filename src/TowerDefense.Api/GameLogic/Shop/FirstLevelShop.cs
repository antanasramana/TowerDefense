using TowerDefense.Api.GameLogic.Items;
using TowerDefense.Api.GameLogic.Items.Models;

namespace TowerDefense.Api.GameLogic.Shop
{
    public class FirstLevelShop : IShop
    {
        public IEnumerable<IItem> Items => new List<IItem> { new Rockets(), new Shield(), new Plane() };
    }
}
