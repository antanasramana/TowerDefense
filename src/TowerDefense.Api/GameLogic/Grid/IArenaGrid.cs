using TowerDefense.Api.GameLogic.Visitor;

namespace TowerDefense.Api.GameLogic.Grid;

public interface IArenaGrid : IAcceptingVisitor
{
    GridItem[] GridItems { get; init; }
}