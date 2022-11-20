using TowerDefense.Api.Models.Player;

namespace TowerDefense.Api.GameLogic.ChainOfResponsibility
{
    public class Request
    {
        public string InventoryId { get; set; }
        public int GridItemId { get; set; }
        public IPlayer Player { get; set; }
        public int RequiredMoney { get; set; }
    }
}
