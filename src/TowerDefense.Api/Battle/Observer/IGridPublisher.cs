using TowerDefense.Api.Models;

namespace TowerDefense.Api.Battle.Observer
{
    public interface IGridPublisher
    {
        // Attach an subscriber to the subject.
        void Attach(IAttackSubscriber subscriber);

        // Detach an subscriber from the subject.
        void Detach(IAttackSubscriber subscriber);

        // Notify all observers about an event.
        public List<AttackResult> Notify(IEnumerable<AttackDeclaration> attackResults);
    }
}
