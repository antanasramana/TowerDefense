using TowerDefense.Api.GameLogic.GameState;

namespace TowerDefense.Api.GameLogic.Memento
{
    public class GameStateMemento : IMemento
    {
        private readonly Game _game;
        private readonly State _state;

        public GameStateMemento(Game game, State state)
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
