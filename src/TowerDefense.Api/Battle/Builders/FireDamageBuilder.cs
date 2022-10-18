namespace TowerDefense.Api.Battle.Builders
{
    public class FireDamageBuilder : IDamageBuilder
    {
        private FireDamage fireDamage;

        public FireDamageBuilder()
        {
            fireDamage = new FireDamage();
        }

        public void Reset()
        {
            fireDamage = new FireDamage();
        }

        public void SetIntensity(float intensity)
        {
            fireDamage.Intensity = intensity;
        }

        public void SetSize(int size)
        {
            fireDamage.Size = size;
        }

        public void SetTime(int time)
        {
            fireDamage.Time = time;
        }

        public Damage GetResult()
        {
            return fireDamage;
        }
    }
}
