using TowerDefense.Api.Models;

namespace TowerDefense.Api.Battle.Observer
{
    public class GridPublisher : IGridPublisher
    {
        private readonly List<IAttackSubscriber> _subscribers = new List<IAttackSubscriber>();

        public void Attach(IAttackSubscriber subscriber)
        {
            _subscribers.Add(subscriber);
        }

        public void Detach(IAttackSubscriber subscriber)
        {
            _subscribers.Remove(subscriber);
        }

        public void Notify(IEnumerable<AttackDeclaration> attackDeclarations)
        {
            foreach (var subscriber in _subscribers)
            {
                foreach (var attackDeclaration in attackDeclarations)
                {
                    if (attackDeclaration != null && attackDeclaration.GridItemId == subscriber.Id)
                    {
                        subscriber.HandleAttack(attackDeclaration);
                    }
                }
            }
        }
    }
}
