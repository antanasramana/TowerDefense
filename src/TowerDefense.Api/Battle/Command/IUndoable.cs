namespace TowerDefense.Api.Battle.Command
{
    public interface IRevertable
    {
        void Undo();
    }
}
