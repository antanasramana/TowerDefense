using TowerDefense.Api.GameLogic.Grid;
using TowerDefense.Api.GameLogic.PerkStorage;
using TowerDefense.Api.GameLogic.Shop;
using TowerDefense.Api.Models.Player;

namespace TowerDefense.Api.GameLogic.Factories
{
    public interface IAbstractLevelFactory
    {
        public IPlayer CreatePlayer(string playerName);
        public IArenaGrid CreateArenaGrid();
        public IShop CreateShop();
        public IPerkStorage CreatePerkStorage();
    }
}
