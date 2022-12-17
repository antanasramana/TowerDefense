namespace TowerDefense.Api.GameLogic.Attacks
{
    public interface IDamage
    {
        public float Intensity { get; set; }
        public int Size { get; set; }
        public int Time { get; set; }
        public DamageType DamageType { get; set; }
    }
}
