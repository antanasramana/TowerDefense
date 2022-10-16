namespace TowerDefense.Api.Battle.Builders
{
    public abstract class Damage
    {
        public abstract DamageType DamageType { get; set; }

        public float Intensity { get; set; }
        public int Size { get; set; }
        public int Time { get; set; }
    }
}
