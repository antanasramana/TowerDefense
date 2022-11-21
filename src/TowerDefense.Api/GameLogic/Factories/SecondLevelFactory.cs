using TowerDefense.Api.GameLogic.Grid;
using TowerDefense.Api.GameLogic.PerkStorage;
using TowerDefense.Api.GameLogic.Shop;
using TowerDefense.Api.Models.Player;

namespace TowerDefense.Api.GameLogic.Factories
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

        public IPerkStorage CreatePerkStorage()
        {
            return new SecondLevelPerkStorage();
        }
    }
}
