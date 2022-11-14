using TowerDefense.Api.GameLogic.Commands;

namespace TowerDefense.Api.GameLogic.Interpreter
{
    public interface ICommandInterpreter
    {
        ICommand InterpretText(string commandText);
    }

    public class CommandInterpreter: ICommandInterpreter
    {
        private readonly IEnumerable<ICommandExpression> _commandExpressions = new List<ICommandExpression>()
        {
            new GiveMoneyExpression(),
            new GiveItemExpression()
        };
        public ICommand InterpretText(string commandText)
        {

            List<string> words = commandText.Split().ToList();

            foreach (var commandExpression in _commandExpressions)
            {
               bool wasInterpreted = commandExpression.Interpret(words);

               if (wasInterpreted)
               {
                   return commandExpression.Evaluate();
               }
            }

            return null;
        }
    }
}
