using TowerDefense.Api.GameLogic.Strategies;
using TowerDefense.Api.Models.Items;
using TowerDefense.Api.Models;

namespace TowerDefense.Api.GameLogic.StatePattern
{
    public class LoadingAtomicBombState : IAtomicBombState
    {
        private AtomicBomb atomicBomb;
        public void SetContext(AtomicBomb atomicBomb)
        {
            this.atomicBomb = atomicBomb;
        }

        public void GoNext()
        {
            IAtomicBombState nextState = new AttackingAtomicBombState();
            nextState.SetContext(atomicBomb);
            atomicBomb.SetState(nextState);
        }

        public bool GoPrevious()
        {
            IAtomicBombState previousState = new BuildingAtomicBombState();
            previousState.SetContext(atomicBomb);
            atomicBomb.SetState(previousState);
            return true;
        }

        public void SetConfiguration()
        {
            this.atomicBomb.Stats = new BasicDefenseItemStats();
            this.atomicBomb.AttackStrategy = new NoAttackStrategy();
            this.atomicBomb.ItemType = ItemType.Loadingatomicbomb;
        }
    }
}
