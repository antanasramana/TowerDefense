using TowerDefense.Api.GameLogic.Visitor;
using TowerDefense.Api.Models.Items;

namespace TowerDefense.Api.Models
{
    public class Inventory : IAcceptingVisitor
    {
        public List<IItem> Items = new();
        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
