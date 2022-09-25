namespace TowerDefense.Api.Battle
{
    public class GameStateSingleton
    {
        public List<Player> Players = new List<Player>();

        private GameStateSingleton() 
        {
        }

        private static readonly GameStateSingleton instance = new GameStateSingleton();
        public static GameStateSingleton Instance => instance;
    }
}
