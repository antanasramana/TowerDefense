namespace TowerDefense.Api.GameLogic.Strategies
{
    public interface IStrategyFlyweightFactory
    {
        public BaseAttackStrategy GetStrategy<T>() where T : BaseAttackStrategy, new();
    }
    public class StrategyFlyweightFactory : IStrategyFlyweightFactory
    {
        private List<BaseAttackStrategy> _attackStrategies;

        public StrategyFlyweightFactory()
        {
            this._attackStrategies = new List<BaseAttackStrategy>();
        }

        public BaseAttackStrategy GetStrategy<T>() where T : BaseAttackStrategy, new()
        {
            foreach (var strategy in _attackStrategies)
            {
                if (strategy.GetType() == typeof(T)) // change to == for memory tests
                {
                    return strategy;
                }
            }

            // If Strategy is not found
            this._attackStrategies.Add(new T());
            return _attackStrategies.Last();
        }
    }
}
