namespace TowerDefense.Api.Battle.Builders
{
    public class DamageBuilderDirector
    {
        public void MakeSmallDamage(IDamageBuilder damageBuilder)
        {
            damageBuilder.SetTime(1);
            damageBuilder.SetSize(2);
            damageBuilder.SetIntensity(0.5f);
        }
        public void MakeBigDamage(IDamageBuilder damageBuilder)
        {
            damageBuilder.SetTime(2);
            damageBuilder.SetSize(2);
            damageBuilder.SetIntensity(1f);
        }
    }
}
