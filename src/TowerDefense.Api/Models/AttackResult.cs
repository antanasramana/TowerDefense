using TowerDefense.Api.Battle.Builders;

namespace TowerDefense.Api.Models
{
    public class AttackResult
    {
        public int GridId { get; set; }
        public Damage Damage { get; set; }
    }
}
