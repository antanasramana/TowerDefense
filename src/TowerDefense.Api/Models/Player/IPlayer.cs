using TowerDefense.Api.Battle.Grid;
using TowerDefense.Api.Battle.Shop;

namespace TowerDefense.Api.Models.Player;

public interface IPlayer
{
    string ConnectionId { get; set; }
    string Name { get; set; }
    int Health { get; set; }
    int Armor { get; set; }
    int Money { get; set; }
    Inventory Inventory { get; set; }
    IArenaGrid ArenaGrid { get; set; }
    IShop Shop { get; set; }
}