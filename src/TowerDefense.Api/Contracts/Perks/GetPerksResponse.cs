using TowerDefense.Api.GameLogic.Perks;

namespace TowerDefense.Api.Contracts.Perks
{
    public class GetPerksResponse
    {
        public IEnumerable<IPerk> Perks { get; set; }
    }
}
