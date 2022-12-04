namespace TowerDefense.Api.GameLogic.Interpreter
{
    public class NumberExpression : IExpression
    {
        public int Amount { get; set; }
        public bool Interpret(List<string> words)
        {
            bool isNumber = int.TryParse(words[0], out int result);
            if (isNumber)
            {
                Amount = result;
                return true;
            }

            return false;
        }
    }
}
