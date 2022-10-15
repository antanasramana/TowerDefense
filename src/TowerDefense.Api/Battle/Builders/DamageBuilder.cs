namespace TowerDefense.Api.Battle.Builders
{
    public interface IDamageBuilder
    {
        void SetSize(int size);
        void SetIntensity(float intensity);
        void SetTime(int time);
    }
}
