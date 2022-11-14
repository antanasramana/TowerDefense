using TowerDefense.Api.GameLogic.Commands;

namespace TowerDefense.Api.GameLogic.Interpreter
{
    public class GiveMoneyExpression : ICommandExpression
    {
        public NumberExpression NumberExpression { get; set; }

        public ICommand Evaluate()
        {
            return new GiveMoneyCommand(NumberExpression.Ammount);
        }

        public bool Interpret(List<string> words)
        {
            if (words[0] != "giveMoney")
            {
                return false;
            }

            NumberExpression = new NumberExpression();

            bool result = NumberExpression.Interpret(words.GetRange(1, words.Count-1));

            return result;
        }
    }
}
