using TowerDefense.Api.Battle.Grid;
using TowerDefense.Api.Battle.Shop;
using TowerDefense.Api.Models.Player;

namespace TowerDefense.Api.Battle.Factories
{
    public class SecondLevelFactory : IAbstractLevelFactory
    {
        public IPlayer CreatePlayer(string playerName)
        {
            return new SecondLevelPlayer()
            {
                Name = playerName
            };
        }

        public IArenaGrid CreateArenaGrid()
        {
            return new SecondLevelArenaGrid();
        }

        public IShop CreateShop()
        {
            return new SecondLevelShop();
        }
    }
}
