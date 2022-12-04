using TowerDefense.Api.Constants;
using TowerDefense.Api.GameLogic.Iterator;
using TowerDefense.Api.GameLogic.Visitor;

namespace TowerDefense.Api.GameLogic.Grid
{
    public class ThirdLevelArenaGrid : IArenaGrid
    {
        public GridItem[] GridItems { get; set; } = new GridItem[Constants.TowerDefense.MaxGridGridItemsForPlayer];

        public ThirdLevelArenaGrid()
        {
            const string gridLayout = @"33322333
                                        33322333
                                        33322333
                                        22333322
                                        22333322
                                        22333322
                                        22333322
                                        22333322
                                        22233222";

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
