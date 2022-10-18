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

        public override IEnumerable<AttackDeclaration> Attack(GridItem[] opponentGridItems, int attackingGridItemId)
        {
            var attackResult = _item.Attack(opponentGridItems, attackingGridItemId).ToList();
            attackResult.ForEach(x => CalculateEarnedMoney(x));
            return attackResult;
        }

        private static void CalculateEarnedMoney(AttackDeclaration attackResult)
        {
            attackResult.EarnedMoney = 10;
        }
    }
}
