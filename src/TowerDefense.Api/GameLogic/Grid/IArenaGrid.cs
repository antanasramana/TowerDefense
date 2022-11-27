using TowerDefense.Api.GameLogic.Iterator;
using TowerDefense.Api.GameLogic.Visitor;

namespace TowerDefense.Api.GameLogic.Grid;

public interface IArenaGrid : IAcceptingVisitor, IIterableCollection
{
    GridItem[] GridItems { get; set; }
}