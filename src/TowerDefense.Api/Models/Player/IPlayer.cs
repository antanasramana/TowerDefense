﻿using TowerDefense.Api.GameLogic.Grid;
using TowerDefense.Api.GameLogic.Observer;
using TowerDefense.Api.GameLogic.PerkStorage;
using TowerDefense.Api.GameLogic.Shop;

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
    IGridPublisher Publisher { get; set; }
    IShop Shop { get; set; }
    IPerkStorage PerkStorage { get; set; }
}
