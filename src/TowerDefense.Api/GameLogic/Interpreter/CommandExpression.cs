using TowerDefense.Api.GameLogic.Commands;

namespace TowerDefense.Api.GameLogic.Interpreter
{
    public interface ICommandExpression : IAbstractExpression
    {
        ICommand Evaluate();
    }
}
