using TowerDefense.Api.Battle.Grid;
using TowerDefense.Api.Battle.Shop;
using TowerDefense.Api.Models.Player;

namespace TowerDefense.Api.Battle.Factories
{
    public interface IAbstractLevelFactory
    {
        public IPlayer CreatePlayer(string playerName);
        public IArenaGrid CreateArenaGrid();
        public IShop CreateShop();
    }
}
