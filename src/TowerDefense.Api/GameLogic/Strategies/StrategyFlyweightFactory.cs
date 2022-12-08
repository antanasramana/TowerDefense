namespace TowerDefense.Api.GameLogic.Strategies
{
    public interface IStrategyFlyweightFactory
    {
        public BaseAttackStrategy GetStrategy(BaseAttackStrategy requestedStrategy);
    }
    public class StrategyFlyweightFactory : IStrategyFlyweightFactory
    {
        private List<BaseAttackStrategy> _attackStrategies;

        public StrategyFlyweightFactory()
        {
            this._attackStrategies = new List<BaseAttackStrategy>();
        }

        public BaseAttackStrategy GetStrategy (BaseAttackStrategy requestedStrategy)
        {
            foreach (var strategy in _attackStrategies) 
            {
                if (strategy.GetType() == requestedStrategy.GetType()) // change to == for memory tests
                {
                    System.Diagnostics.Debug.WriteLine("Found same");
                    return strategy;
                } 
            }

            // If Strategy is not found
            this._attackStrategies.Add(requestedStrategy);
            System.Diagnostics.Debug.WriteLine("added new");
            return _attackStrategies.Last();
        }
    }
}
