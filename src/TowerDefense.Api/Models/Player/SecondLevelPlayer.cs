﻿using TowerDefense.Api.GameLogic.Commands;
using TowerDefense.Api.GameLogic.Grid;
using TowerDefense.Api.GameLogic.Observer;
using TowerDefense.Api.GameLogic.PerkStorage;
using TowerDefense.Api.GameLogic.Shop;

namespace TowerDefense.Api.Models.Player
{
    public class SecondLevelPlayer : IPlayer
    {
        public string ConnectionId { get; set; }
        public string Name { get; set; }
        public int Health { get; set; } = 60;
        public int Armor { get; set; } = 60;
        public int Money { get; set; } = 5000;
        public Inventory Inventory { get; set; } = new Inventory();
        public IArenaGrid ArenaGrid { get; set; } = null;
        public IShop Shop { get; set; } = null;
        public IGridPublisher Publisher { get; set; } = new GridPublisher();
        public ICommandHistory CommandHistory { get; set; } = new CommandHistory();
        public IPerkStorage PerkStorage { get; set; } = null;
    }
}
