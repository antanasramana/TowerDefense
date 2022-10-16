namespace TowerDefense.Api.Battle.Builders
{
    public class ProjectileDamageBuilder : IDamageBuilder
    {
        private ProjectileDamage projectileDamage;

        public ProjectileDamageBuilder()
        {
            projectileDamage = new ProjectileDamage();
        }

        public void Reset()
        {
            this.projectileDamage = new ProjectileDamage();
        }
        public void SetIntensity(float intensity)
        {
            this.projectileDamage.Intensity = intensity;

        }

        public void SetSize(int size)
        {
            this.projectileDamage.Size = size;
        }

        public void SetTime(int time)
        {
            this.projectileDamage.Time = time;
        }

        public Damage GetResult()
        {
            return this.projectileDamage;
        }
    }
}
