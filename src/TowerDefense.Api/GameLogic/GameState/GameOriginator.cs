namespace TowerDefense.Api.GameLogic.GameState
{
    public class GameOriginator
    {
        private GameOriginator() { }
        public static GameOriginator Instance { get; } = new();
        public State State { get; set; } = new();
    }
}
