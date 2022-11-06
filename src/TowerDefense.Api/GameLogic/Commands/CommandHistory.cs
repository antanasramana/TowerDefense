namespace TowerDefense.Api.GameLogic.Commands
{
    public interface ICommandHistory
    {
        void Push(ICommand command);
        ICommand Pop();
        void Clear();
    }
    public class CommandHistory : ICommandHistory
    {
        private readonly Stack<ICommand> _executedCommands = new Stack<ICommand>();
        public void Push(ICommand command)
        {
            _executedCommands.Push(command);
        }
        public ICommand Pop()
        {
            if (_executedCommands.Count == 0)
            {
                return null;
            }
            return _executedCommands.Pop();
        }

        public void Clear()
        {
            _executedCommands.Clear();
        }
    }
}
