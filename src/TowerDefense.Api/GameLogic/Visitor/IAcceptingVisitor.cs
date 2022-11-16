namespace TowerDefense.Api.GameLogic.Visitor
{
    public interface IAcceptingVisitor
    {
        void Accept(IVisitor visitor);
    }
}
