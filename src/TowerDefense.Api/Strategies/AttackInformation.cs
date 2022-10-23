using TowerDefense.Api.Battle.Grid;

namespace TowerDefense.Api.Strategies
{
    public class AttackInformation
    {
        public int AttackingItemRow { get; set; }
        public List<GridRow> OpponentsGridItems { get; set; }
    }
}
