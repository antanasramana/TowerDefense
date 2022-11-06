namespace TowerDefense.Api.GameLogic.Builders
{
    public class ProjectileDamage: Damage
    {
        public override DamageType DamageType { get; set; } = DamageType.Projectile;
    }
}
