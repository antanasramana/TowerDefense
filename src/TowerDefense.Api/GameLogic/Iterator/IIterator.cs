using TowerDefense.Api.GameLogic.Grid;

namespace TowerDefense.Api.GameLogic.Iterator
{
    public interface IIterator
    {
        bool IsLast();
        bool HasMore();
        GridItem GetNext();
        GridItem GetPrevious();
    }
}
