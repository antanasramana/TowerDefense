namespace TowerDefense.Api.Battle.Command
{
    public class CommandHistory
    {
        private readonly Stack<IRevertable> _executedCommands = new Stack<IRevertable>();
        public void Push(IRevertable command)
        {
            _executedCommands.Push(command);
        }
        public IRevertable Pop()
        {
            return _executedCommands.Pop();
        }
    }
}
