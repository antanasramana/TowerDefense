namespace TowerDefense.Api.GameLogic.Composite
{
    public interface IExpressionComponent
    {
        void Execute(string playerName);
        bool IsComposite();
    }
}
