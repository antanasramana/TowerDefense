using TowerDefense.Api.Enums;
using TowerDefense.Api.GameLogic.GameState;
using TowerDefense.Api.GameLogic.Grid;
using TowerDefense.Api.Models;
using TowerDefense.Api.Models.Player;

namespace TowerDefense.Api.GameLogic.Visitor
{
    public class RestorePerkVisitor : IVisitor
    {
        private readonly GameOriginator _game;

        public RestorePerkVisitor()
        {
            _game = GameOriginator.Instance;
        }
        public void Visit(Inventory inventory)
        {
        }

        public void Visit(IPlayer player)
        {
            var firstLevelPlayer = new FirstLevelPlayer();
            var secondLevelPlayer = new SecondLevelPlayer();
            var thirdLevelPlayer = new ThirdlevelPlayer();

            player.Health = _game.State.Level switch
            {
                Level.First => firstLevelPlayer.Health,
                Level.Second => secondLevelPlayer.Health,
                Level.Third => thirdLevelPlayer.Health,
                _ => throw new ArgumentOutOfRangeException()
            };

            player.Armor = _game.State.Level switch
            {
                Level.First => firstLevelPlayer.Armor,
                Level.Second => secondLevelPlayer.Armor,
                Level.Third => thirdLevelPlayer.Armor,
                _ => throw new ArgumentOutOfRangeException()
            };

            player.Money = _game.State.Level switch
            {
                Level.First => firstLevelPlayer.Money,
                Level.Second => secondLevelPlayer.Money,
                Level.Third => thirdLevelPlayer.Money,
                _ => throw new ArgumentOutOfRangeException()
            };
        }

        public void Visit(IArenaGrid arenaGrid)
        {
            foreach (var gridItem in arenaGrid.GridItems)
            {
                gridItem.Item.Stats = gridItem.Item.Stats switch
                {
                    DefaultZeroItemStats defaultStats => new DefaultZeroItemStats(),
                    HighCostNoHealthItemStats highCostNoHealthStats => new HighCostNoHealthItemStats(),
                    HighDamageItemStats highDamageStats => new HighDamageItemStats(),
                    SpecialItemStats specialStats => new SpecialItemStats(),
                    HighHealthItemStats highHealthStats => new HighHealthItemStats(),
                    MediumCostHighDamageItemStats mediumCostHighDamageStats => new MediumCostHighDamageItemStats(),
                    BasicDefenseItemStats basicDefenseStats => new BasicDefenseItemStats(),
                    RegularDefaultItemStats regularDefaultStats => new RegularDefaultItemStats(),
                    _ => throw new ArgumentOutOfRangeException()
                };
            }
        }
    }
}
