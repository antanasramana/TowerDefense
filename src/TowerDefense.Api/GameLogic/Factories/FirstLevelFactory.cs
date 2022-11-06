using TowerDefense.Api.GameLogic.Grid;
using TowerDefense.Api.GameLogic.Shop;
using TowerDefense.Api.Models.Player;

namespace TowerDefense.Api.GameLogic.Factories
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
