using TowerDefense.Api.Battle.Grid;
using TowerDefense.Api.Models;
using TowerDefense.Api.Models.Items;

namespace TowerDefense.Api.Decorator
{
    public class HealthDecorator : BaseDecorator
    {
        public HealthDecorator(IItem item) : base(item)
        {
            Health = IncreaseHealth(item.Health);
        }

        public override IEnumerable<AttackDeclaration> Attack(IArenaGrid opponentsArenaGrid, int attackingGridItemId)
        {
            return _item.Attack(opponentsArenaGrid, attackingGridItemId);
        }
        
        private static int IncreaseHealth(int health)
        {
            return health + 10;
        }
    }
}
