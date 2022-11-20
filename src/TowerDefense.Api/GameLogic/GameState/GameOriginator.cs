using Force.DeepCloner;
using TowerDefense.Api.GameLogic.Memento;

namespace TowerDefense.Api.GameLogic.GameState
{
    public class GameOriginator
    {
        private GameOriginator() { }
        public static GameOriginator Instance { get; } = new();
        public State State { get; set; } = new();

        public IMemento SaveSnapshot()
        {
            return new GameStateMemento(Instance, State.DeepClone());
        }
    }
}
