using TowerDefense.Api.Battle.Grid;
using TowerDefense.Api.Models.Items;
using TowerDefense.Api.Models;

namespace TowerDefense.Api.Decorator
{
    public class MoneyDecorator : BaseDecorator
    {
        public MoneyDecorator(IItem item) : base(item)
        {
        }

        public override IEnumerable<AttackDeclaration> Attack(IArenaGrid opponentsArenaGrid, int attackingGridItemId)
        {
            var attackDeclarations = _item.Attack(opponentsArenaGrid, attackingGridItemId).ToList();
            attackDeclarations.ForEach(x => SetEarnedMoney(x));
            return attackDeclarations;
        }

        private static void SetEarnedMoney(AttackDeclaration attackDeclaration)
        {
            attackDeclaration.EarnedMoney = 10;
        }
    }
}
