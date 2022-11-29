namespace TowerDefense.Api.GameLogic.Composite
{
    public interface ExpressionComponent
    {
        void Execute(string playerName);
        bool IsComposite();
    }
}
