namespace TowerDefense.Api.GameLogic.Interpreter
{
    public interface IExpression
    { 
        bool Interpret(List<string> words);
    }
}
