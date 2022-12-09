using TowerDefense.Api.GameLogic.Builders;
using TowerDefense.Api.GameLogic.GameState;
using TowerDefense.Api.GameLogic.Grid;
using TowerDefense.Api.GameLogic.StatePattern;
using TowerDefense.Api.GameLogic.Strategies;

namespace TowerDefense.Api.Models.Items
{
    public class AtomicBomb : IItem
    {
        public string Id { get; set; } = nameof(AtomicBomb);
        public int Level { get; set; } = 0;
        public ItemType ItemType { get; set; } = ItemType.Atomicbomb;
        public IItemStats Stats { get; set; } = new SmallDefenseItemStats();
        public BaseAttackStrategy AttackStrategy { get; set; } = GameOriginator.Instance.FlyweightFactory.GetStrategy(new NoAttackStrategy());
        public ICollection<string> PowerUps { get; set; } = new List<string>();

        private IAtomicBombState state = new BuildingAtomicBombState();

        public AtomicBomb()
        {
            state.SetContext(this);
        }
        public void SetState(IAtomicBombState state)
        {
            this.state = state;
        }

        public void NextState()
        {
            this.state.GoNext();
        }

        public bool PreviousState()
        {
            return this.state.GoPrevious();
        }

        public IEnumerable<AttackDeclaration> Attack(IArenaGrid opponentsArenaGrid, int attackingGridItemId)
        {
            this.state.SetConfiguration();
            var affectedGridItemList = AttackStrategy.AttackedGridItems(opponentsArenaGrid, attackingGridItemId);
            return affectedGridItemList.Select(x => new AttackDeclaration() { GridItemId = x, Damage = Stats.Damage, DamageType = DamageType.Fire });
        }

        public IItem Clone()
        {
            return new AtomicBomb
            {
                Id = Guid.NewGuid().ToString()
            };
        }
    }
}
