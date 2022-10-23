using TowerDefense.Api.Models;
using TowerDefense.Api.Models.Items;
using TowerDefense.Api.Strategies;

namespace TowerDefense.Api.Adapter
{
    public class AttackStrategyAdapter
    {
        private readonly IItem _adaptee;
        public AttackStrategyAdapter(IItem adaptee)
        {
            _adaptee = adaptee;
        }
        //public IEnumerable<AttackDeclaration> Attack
    }
}
