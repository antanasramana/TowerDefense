using TowerDefense.Api.Models;

namespace TowerDefense.Api.Battle.Observer
{
    public interface IGridObserverPublisher
    {
        // Attach an observer to the subject.
        void Attach(IAttackSubscriber observer);

        // Detach an observer from the subject.
        void Detach(IAttackSubscriber observer);

        // Notify all observers about an event.
        public void Notify(IEnumerable<AttackResult> events);
    }
}
