namespace TowerDefense.Api.GameLogic.Interpreter
{
    public class NumberExpression : IAbstractExpression
    {
        public int Ammount { get; set; }
        public bool Interpret(List<string> words)
        {
            bool isNumber = int.TryParse(words[0], out int result);
            if (isNumber)
            {
                Ammount = result;
                return true;
            }

            return false;
        }
    }
}
