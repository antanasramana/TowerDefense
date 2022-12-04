using TowerDefense.Api.GameLogic.Grid;

namespace TowerDefense.Api.GameLogic.Strategies
{
    public abstract class BaseAttackStrategy
    {
        public IEnumerable<int> AttackedGridItems(IArenaGrid opponentsArenaGrid, int attackingGridItemId)
        {
            if (isItemOffensive())
            {
                return AttackStrategy(opponentsArenaGrid, attackingGridItemId);
            }
            else
            {
                return new List<int>();
            }
        }

        protected virtual IEnumerable<int> AttackStrategy(IArenaGrid opponentsArenaGrid, int attackingGridItemId) 
        {
            return new List<int>();
        }

        protected virtual bool isItemOffensive() {
            return false;
        }
    }
}
