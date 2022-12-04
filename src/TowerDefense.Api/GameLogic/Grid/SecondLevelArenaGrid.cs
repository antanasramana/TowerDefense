using TowerDefense.Api.Constants;
using TowerDefense.Api.GameLogic.Iterator;
using TowerDefense.Api.GameLogic.Visitor;

namespace TowerDefense.Api.GameLogic.Grid
{
    public class SecondLevelArenaGrid : IArenaGrid
    {
        public GridItem[] GridItems { get; set; } = new GridItem[Constants.TowerDefense.MaxGridGridItemsForPlayer];

        public SecondLevelArenaGrid()
        {
            const string gridLayout = @"32222222
                                        33222222
                                        33322222
                                        33332222
                                        33333222
                                        33332222
                                        33322222
                                        33222222
                                        32222222";

            GridItems.CreateGrid(gridLayout);
        }

        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }

        public IIterator GetIterator(int rowId)
        {
            return new ArrayIterator(this, rowId);
        }
    }
}
