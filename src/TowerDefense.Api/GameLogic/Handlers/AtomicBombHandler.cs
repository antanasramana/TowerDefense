using TowerDefense.Api.GameLogic.Grid;
using TowerDefense.Api.GameLogic.StatePattern;
using TowerDefense.Api.Models.Items;

namespace TowerDefense.Api.GameLogic.Handlers
{
    public interface IAtomicBombHandler
    {
        void UpdateState(IArenaGrid playerArenaGrid);
    }
    public class AtomicBombHandler : IAtomicBombHandler
    {
        public void UpdateState(IArenaGrid playerArenaGrid)
        {
            List<AtomicBomb> bombs = playerArenaGrid.GridItems.Where(x => x.Item is AtomicBomb).Select(x => x.Item as AtomicBomb).ToList();
            foreach (AtomicBomb atomicBomb in bombs)
            {
                atomicBomb.NextState();
            }
        }
    }
}
