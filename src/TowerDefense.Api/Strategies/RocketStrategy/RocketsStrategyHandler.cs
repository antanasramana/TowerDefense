using TowerDefense.Api.Enums;

namespace TowerDefense.Api.Strategies.RocketStrategy
{
    public static class RocketsStrategyHandler
    {
        public static IRocketsStrategy CreateRocketsStrategy(Level level)
        {
            return level switch
            {
                Level.First => new FirstLevelRocketStrategy(),
                Level.Second => new SecondLevelRocketStrategy(),
                Level.Third => new ThirdLevelRocketStrategy(),
                _ => throw new ArgumentOutOfRangeException()
            };
        }
    }
}
