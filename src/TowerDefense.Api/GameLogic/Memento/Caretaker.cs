﻿namespace TowerDefense.Api.GameLogic.Memento
{
    public interface ICaretaker
    {
        void Clear();
        void AddSnapshot(IMemento memento);
        IMemento GetPreviousState();
    }

    public class Caretaker : ICaretaker
    {
        private Stack<IMemento> _snapshotHistory = new Stack<IMemento>();

        public void Clear()
        {
            _snapshotHistory.Clear();
        }

        public void AddSnapshot(IMemento memento)
        {
            _snapshotHistory.Push(memento);
        }
        public IMemento GetPreviousState()
        {
            _snapshotHistory.Pop();
            return _snapshotHistory.Peek();
        }
    }
}
