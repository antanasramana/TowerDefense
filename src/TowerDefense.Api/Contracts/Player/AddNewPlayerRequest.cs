using TowerDefense.Api.Enums;

namespace TowerDefense.Api.Contracts.Player
{
    public class AddNewPlayerRequest
    {
        public string PlayerName { get; set; }
        public Level Level { get; set; }
    }
}
