using TowerDefense.Api.GameLogic.Grid;

namespace TowerDefense.Api.GameLogic.Iterator
{
    public interface IIterableCollection
    {
        IIterator GetIterator(int index);
    }
}
