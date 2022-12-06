using Microsoft.AspNetCore.Authorization.Infrastructure;
using TowerDefense.Api.GameLogic.Strategies;
using TowerDefense.Api.Models;
using TowerDefense.Api.Models.Items;

namespace TowerDefense.Api.GameLogic.StatePattern
{
    public class BuildingAtomicBombState : IAtomicBombState
    {
        private AtomicBomb atomicBomb;

        public void GoNext()
        {
            IAtomicBombState nextState = new HiddingAtomicBombStateIAtomicBombState();
            nextState.SetContext(atomicBomb);
            atomicBomb.SetState(nextState);
        }

        public bool GoPrevious()
        {
            return false;
        }

        public void SetConfiguration()
        {
            this.atomicBomb.Stats = new SmallDefenseItemStats();
            this.atomicBomb.AttackStrategy = new NoAttackStrategy();
            this.atomicBomb.ItemType = ItemType.Atomicbomb;
        }

        public void SetContext(AtomicBomb atomicBomb)
        {
            this.atomicBomb = atomicBomb;
        }
    }
}
