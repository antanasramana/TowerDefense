using TowerDefense.Api.GameLogic.Builders;

namespace TowerDefense.Api.Models
{
    public class AttackDeclaration
    {
        public int GridItemId { get; set; }
        public int Damage { get; set; }

        public DamageType DamageType { get; set; } = DamageType.Projectile; // Setting to avoid nulls
        public int EarnedMoney { get; set; } = 0;
    }
}
