namespace TowerDefense.Api.Battle.Builders
{
    public class FireDamage : Damage
    {
        public override DamageType DamageType { get; set; } = DamageType.Fire;
    }
}
