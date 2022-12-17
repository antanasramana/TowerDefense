namespace TowerDefense.Api.GameLogic.Attacks
{
    public class FireDamage : IDamage
    {
        public float Intensity { get; set; } = 1;
        public int Size { get; set; } = 1;
        public int Time { get; set; } = 1;
        public DamageType DamageType { get; set; } = DamageType.Fire;
    }
}
