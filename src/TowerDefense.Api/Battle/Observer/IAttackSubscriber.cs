using TowerDefense.Api.Models;

namespace TowerDefense.Api.Battle.Observer
{
    public interface IAttackSubscriber
    {
        public int Id { get; set; }
        public void HandleAttack(AttackDeclaration atackDeclaration);
    }
}
