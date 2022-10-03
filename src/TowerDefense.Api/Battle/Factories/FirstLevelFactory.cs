using TowerDefense.Api.Battle.Grid;
using TowerDefense.Api.Battle.Shop;
using TowerDefense.Api.Models.Player;

namespace TowerDefense.Api.Battle.Factories
{
    public class FirstLevelFactory : IAbstractLevelFactory
    {
        public IPlayer CreatePlayer(string playerName)
        {
            return new FirstLevelPlayer
            {
                Name = playerName
            };
        }

        public IArenaGrid CreateArenaGrid()
        {
            return new FirstLevelArenaGrid();
        }

        public IShop CreateShop()
        {
            return new FirstLevelShop();
        }
    }
}
