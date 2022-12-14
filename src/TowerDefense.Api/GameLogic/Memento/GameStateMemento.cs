using TowerDefense.Api.GameLogic.GameState;
using TowerDefense.Api.GameLogic.Strategies;

namespace TowerDefense.Api.GameLogic.Memento
{
    public class GameStateMemento : IMemento
    {
        private readonly GameOriginator _game;
        private readonly State _state;

        public GameStateMemento(GameOriginator game, State state)
        {
            _game = game;
            _state = state;
        }

        public void Restore()
        {
            _game.State = _state;
        }
    }
}
