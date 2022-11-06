using TowerDefense.Api.Models;

namespace TowerDefense.Api.GameLogic.Observer
{
    public interface IAttackSubscriber
    {
        public int Id { get; set; }
        public AttackResult HandleAttack(AttackDeclaration atackDeclaration);
    }
}
