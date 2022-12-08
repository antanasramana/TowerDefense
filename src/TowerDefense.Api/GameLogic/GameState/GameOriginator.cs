using Force.DeepCloner;
using TowerDefense.Api.GameLogic.Memento;
using TowerDefense.Api.GameLogic.Strategies;

namespace TowerDefense.Api.GameLogic.GameState
{
    public class GameOriginator
    {
        private GameOriginator() { }
        public static GameOriginator Instance { get; } = new();
        public State State { get; set; } = new();

        public IStrategyFlyweightFactory FlyweightFactory { get; } = new StrategyFlyweightFactory();

        public IMemento SaveSnapshot()
        {
            return new GameStateMemento(Instance, State.DeepClone());
        }
    }
}
