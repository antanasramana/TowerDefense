using TowerDefense.Api.GameLogic.Grid;
using TowerDefense.Api.GameLogic.Shop;
using TowerDefense.Api.Models.Player;

namespace TowerDefense.Api.GameLogic.Factories
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
