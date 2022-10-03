using TowerDefense.Api.Battle.Grid;
using TowerDefense.Api.Battle.Shop;
using TowerDefense.Api.Models.Player;

namespace TowerDefense.Api.Battle.Factories
{
    public class ThirdLevelFactory : IAbstractLevelFactory
    {
        public IPlayer CreatePlayer(string playerName)
        {
            return new ThirdlevelPlayer()
            {
                Name = playerName
            };
        }

        public IArenaGrid CreateArenaGrid()
        {
            return new ThirdLevelArenaGrid();
        }

        public IShop CreateShop()
        {
            return new ThirdLevelShop();
        }
    }
}
