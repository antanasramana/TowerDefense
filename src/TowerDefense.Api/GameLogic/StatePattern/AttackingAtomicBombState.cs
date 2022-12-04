using TowerDefense.Api.GameLogic.Strategies;
using TowerDefense.Api.Models.Items;
using TowerDefense.Api.Models;

namespace TowerDefense.Api.GameLogic.StatePattern
{
    public class AttackingAtomicBombState : IAtomicBombState
    {
        private AtomicBomb atomicBomb;

        public void SetContext(AtomicBomb atomicBomb)
        {
            this.atomicBomb = atomicBomb;
        }

        public void GoNext()
        {
        }

        public void GoPrevious()
        {
            IAtomicBombState previousState = new LoadingAtomicBombState();
            previousState.SetContext(atomicBomb);
            atomicBomb.SetState(previousState);
        }

        public void SetConfiguration()
        {
            this.atomicBomb.Stats = new AtomicBombItemStats();
            this.atomicBomb.AttackStrategy = new AtomicAttackStrategy();
            this.atomicBomb.ItemType = ItemType.Attackingatomicbomb;
        }
    }
}
