using TowerDefense.Api.Models;
using TowerDefense.Api.Models.Items;
using static System.Net.Mime.MediaTypeNames;

namespace TowerDefense.Api.Battle.Observer
{
    public class GridObserverPublisher : IGridObserverPublisher
    {
        private List<IAttackSubscriber> _subscribers = new List<IAttackSubscriber>();

        public void Attach(IAttackSubscriber observer)
        {
            System.Diagnostics.Debug.WriteLine("Subject: Attached an observer.");
            this._subscribers.Add(observer);
        }

        public void Detach(IAttackSubscriber observer)
        {
            this._subscribers.Remove(observer);
            System.Diagnostics.Debug.WriteLine("Subject: Detached an observer.");
        }

        public void Notify(IEnumerable<AttackResult> events)
        {
            System.Diagnostics.Debug.WriteLine("Subject: Notifying observers...");

            foreach (var subscriber in _subscribers)
            {
                foreach (var attack in events)
                {
                    if (attack != null && attack.GridItemId == subscriber.Id)
                    {
                        subscriber.HandleAttack(attack.Damage);
                    }
                }
            }
        }

        public GridObserverPublisher()
        {
            
        }
    }
}
