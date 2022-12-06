using TowerDefense.Api.GameLogic.Grid;

namespace TowerDefense.Api.GameLogic.Strategies
{
    public class NoAttackStrategy : BaseAttackStrategy
    {
        protected sealed override bool isItemOffensive()
        {
            return false;
        }
    }
}
