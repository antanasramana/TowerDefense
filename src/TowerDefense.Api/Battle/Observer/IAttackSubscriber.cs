using TowerDefense.Api.Models;

namespace TowerDefense.Api.Battle.Observer
{
    public interface IAttackSubscriber
    {
        public int Id { get; set; }
        public AttackResult HandleAttack(AttackDeclaration atackDeclaration);
    }
}
