namespace TowerDefense.Api.GameLogic.Interpreter
{
    public interface IAbstractExpression
    { 
        bool Interpret(List<string> words);
    }
}
