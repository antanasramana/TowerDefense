﻿using TowerDefense.Api.Constants;
using TowerDefense.Api.GameLogic.Iterator;
using TowerDefense.Api.GameLogic.Visitor;

namespace TowerDefense.Api.GameLogic.Grid
{
    public class FirstLevelArenaGrid : IArenaGrid
    {
        public GridItem[] GridItems { get; set; } = new GridItem[Constants.TowerDefense.MaxGridGridItemsForPlayer];

        public FirstLevelArenaGrid()
        {
            const string gridLayout = @"33333333
                                        33333333
                                        33333333
                                        33333333
                                        33333333
                                        33333333
                                        33333333
                                        33333333
                                        33333333";

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
