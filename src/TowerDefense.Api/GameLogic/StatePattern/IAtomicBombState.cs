using TowerDefense.Api.Models.Items;

namespace TowerDefense.Api.GameLogic.StatePattern
{
    public interface IAtomicBombState
    {
        void SetContext(AtomicBomb atomicBomb);
        void GoNext();
        bool GoPrevious();
        void SetConfiguration();
    }
}
