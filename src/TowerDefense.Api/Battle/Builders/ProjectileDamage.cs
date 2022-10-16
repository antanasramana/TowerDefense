namespace TowerDefense.Api.Battle.Builders
{
    public class ProjectileDamage: Damage
    {
        public override DamageType DamageType { get; set; } = DamageType.Projectile;
    }
}
