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

        public void GoPrevious()
        {
            IAtomicBombState previousState = new HiddingAtomicBombStateIAtomicBombState();
            previousState.SetContext(atomicBomb);
            atomicBomb.SetState(previousState);
        }

        public void SetConfiguration()
        {
            this.atomicBomb.Stats = new BasicDefenseItemStats();
            this.atomicBomb.AttackStrategy = new NoAttackStrategy();
            this.atomicBomb.ItemType = ItemType.Loadingatomicbomb;
        }
    }
}
