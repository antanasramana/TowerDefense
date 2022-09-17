using TowerDefense.Shared.Models;

namespace TowerDefense.Api.Battle
{
    public class GameStateSingleton
    {
        public List<TurnEnd> TurnEnds = new List<TurnEnd>();

        private GameStateSingleton() 
        {
        }

        private static readonly GameStateSingleton instance = new GameStateSingleton();
        public static GameStateSingleton Instance => instance;
    }
}
