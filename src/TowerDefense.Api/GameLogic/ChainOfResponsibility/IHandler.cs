using TowerDefense.Api.Models.Items;

namespace TowerDefense.Api.GameLogic.ChainOfResponsibility
{
    public interface IHandler
    {
        public IHandler NextHandler { set; }
        IItem Handle(Request request);
    }
}
