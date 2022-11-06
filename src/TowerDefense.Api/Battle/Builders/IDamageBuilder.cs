namespace TowerDefense.Api.GameLogic.Builders
{
    public interface IDamageBuilder
    {
        void Reset();
        void SetSize(int size);
        void SetIntensity(float intensity);
        void SetTime(int time);
        Damage GetResult();
    }
}
