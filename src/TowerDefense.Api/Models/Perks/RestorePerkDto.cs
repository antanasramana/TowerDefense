using TowerDefense.Api.GameLogic.Grid;
using TowerDefense.Api.GameLogic.Visitor;
using TowerDefense.Api.Models.Player;

namespace TowerDefense.Api.Models.Perks
{
    public class RestorePerkDto : IPerkDto
    {
        public int Id { get; init; }
        public string Name => "Back in Time!";
    }
}
