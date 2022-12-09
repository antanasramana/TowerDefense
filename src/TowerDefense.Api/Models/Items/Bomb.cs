using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using TowerDefense.Api.GameLogic.GameState;
using TowerDefense.Api.GameLogic.Grid;
using TowerDefense.Api.GameLogic.Handlers;
using TowerDefense.Api.GameLogic.Strategies;

namespace TowerDefense.Api.Models.Items
{
    public class Bomb : IItem
    {
        public string Id { get; set; } = nameof(Bomb);
        public int Level { get; set; } = 0;
        public ItemType ItemType { get; set; } = ItemType.Bomb;
        public IItemStats Stats { get; set; } = new HighCostNoHealthItemStats();
        public ICollection<string> PowerUps { get; set; } = new List<string>();
        public BaseAttackStrategy AttackStrategy { get; set; } = GameOriginator.Instance.FlyweightFactory.GetStrategy(new FirstInHorizontalLineAttackStrategy());

        public IEnumerable<AttackDeclaration> Attack(IArenaGrid opponentsArenaGrid, int attackingGridItemId)
        {
            var affectedGridItemList = AttackStrategy.AttackedGridItems(opponentsArenaGrid, attackingGridItemId);
            return affectedGridItemList.Select(x => new AttackDeclaration() { GridItemId = x, Damage = Stats.Damage });
        }

        public IItem Clone()
        {
            return new Bomb
            {
                Id = Guid.NewGuid().ToString()
            };
        }
    }
}
