using TowerDefense.Api.Battle.Grid;
using TowerDefense.Api.Models.Items;
using TowerDefense.Api.Models;
using TowerDefense.Api.Adapter;

namespace TowerDefense.Api.Decorator
{
    public class MoneyDecorator : BaseDecorator
    {
        public MoneyDecorator(IItem item) : base(item)
        {
        }

        public override IEnumerable<AttackDeclaration> Attack(GridItem[] opponentGridItems, int attackingGridItemId)
        {
            var attackDeclarations = _item.Attack(opponentGridItems, attackingGridItemId).ToList();
            attackDeclarations.ForEach(x => SetEarnedMoney(x));
            return attackDeclarations;
        }

        private static void SetEarnedMoney(AttackDeclaration attackDeclaration)
        {
            attackDeclaration.EarnedMoney = 10;
        }
    }
}
