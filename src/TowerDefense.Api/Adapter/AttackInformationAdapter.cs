using TowerDefense.Api.Battle.Grid;
using TowerDefense.Api.Constants;
using TowerDefense.Api.Strategies;

namespace TowerDefense.Api.Adapter
{
    public class AttackInformationAdapter
    {
        private readonly IAttackStrategy _adaptee;
        public AttackInformationAdapter(IAttackStrategy adaptee)
        {
            _adaptee = adaptee;
        }
        public IEnumerable<int> AttackedGridItems(GridItem[] opponentsGridItems, int attackingItemdId)
        {
            int attackingItemRow = GetItemRow(attackingItemdId);
            var opponentsGridItemsRows = GetOpponentsGridRows(opponentsGridItems);
            return _adaptee.AttackedGridItems(new AttackInformation { AttackingItemRow = attackingItemRow, OpponentsGridItems = opponentsGridItemsRows });
        }
        private static int GetItemRow(int gridItemId)
        {
            return gridItemId / Game.MaxGridGridItemsInRow;
        }
        private static List<GridRow> GetOpponentsGridRows(GridItem[] opponentsGridItems)
        {
            var opponentsGridRows = new List<GridRow>();
            for (int i = 0; i < opponentsGridItems.Length; i += Game.MaxGridGridItemsInRow)
            {
                var rowId = GetItemRow(i);
                var lastItemInTheRowId = i + Game.MaxGridGridItemsInRow - 1;
                var rowsGridItems = opponentsGridItems.Where(x => i <= x.Id && x.Id <= lastItemInTheRowId )
                                                      .OrderByDescending(x => x.Id)
                                                      .ToList();
                var gridRow = new GridRow { RowId = rowId, GridItems = rowsGridItems };
                opponentsGridRows.Add(gridRow);
            }
            return opponentsGridRows;
        }
    }
}
