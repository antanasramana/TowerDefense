using TowerDefense.Api.Models;

namespace TowerDefense.Api.GameLogic.Observer
{
    public class GridPublisher : IGridPublisher
    {
        private readonly List<IAttackSubscriber> Subscribers = new List<IAttackSubscriber>();

        public void Attach(IAttackSubscriber subscriber)
        {
            Subscribers.Add(subscriber);
        }

        public void Detach(IAttackSubscriber subscriber)
        {
            Subscribers.Remove(subscriber);
        }

        public List<AttackResult> Notify(IEnumerable<AttackDeclaration> attackDeclarations)
        {
            List<AttackResult> attackResults = new List<AttackResult>();

            foreach (var subscriber in Subscribers)
            {
                foreach (var attackDeclaration in attackDeclarations)
                {
                    if (attackDeclaration != null && attackDeclaration.GridItemId == subscriber.Id)
                    {
                        var attackResult = subscriber.HandleAttack(attackDeclaration);
                        attackResults.Add(attackResult);
                    }
                }
            }

            return attackResults;
        }
    }
}
