namespace TowerDefense.Api.Battle.Command
{
    public class CommandHandler
    {
        private readonly CommandHistory _commandHistory = new CommandHistory();

        public void Execute(Command command)
        {
            command.Execute();
            if (command is IRevertable revertable)
            {
                _commandHistory.Push(revertable);
            }
        }

        public void Undo()
        {
            var lastCommand = _commandHistory.Pop();
            lastCommand.Undo();
        }
    }
}
