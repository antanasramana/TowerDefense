using TowerDefense.Api.GameLogic.Strategies;
using TowerDefense.Api.Models.Items;
using TowerDefense.Api.Models;

namespace TowerDefense.Api.GameLogic.StatePattern
{
    public class HiddingAtomicBombStateIAtomicBombState : IAtomicBombState
    {
        private AtomicBomb atomicBomb;

        public void GoNext()
        {
            IAtomicBombState nextState = new LoadingAtomicBombState();
            nextState.SetContext(atomicBomb);
            atomicBomb.SetState(nextState);
        }

        public bool GoPrevious()
        {
            return false;
        }

        public void SetConfiguration()
        {
            this.atomicBomb.Stats = new InvinsibleDefenseItemStats();
            this.atomicBomb.AttackStrategy = new NoAttackStrategy();
            this.atomicBomb.ItemType = ItemType.Hiddingatomicbomb;
        }
        public void SetContext(AtomicBomb atomicBomb)
        {
            this.atomicBomb = atomicBomb;
        }
    }
}
